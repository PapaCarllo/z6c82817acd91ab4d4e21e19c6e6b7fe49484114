using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PokerFramework.Common
{
    [DebuggerDisplay("Count = {Count}")]
    [DebuggerTypeProxy("System.Collections.Generic.Mscorlib_CollectionDebugView`1")]
    public class ReadOnlyList<T> : IReadOnlyList<T>, IList<T>, IIsImmutable
    {
        private readonly IList<T> _baseList;

        private readonly int? _count;

        private readonly bool _isImmutable;

        private readonly int _offset;

        public ReadOnlyList(bool createAsImmutable, IList<T> baseList, int offset, int? count = null)
        {
            if (ReferenceEquals(null, baseList) || offset < 0 || offset > baseList.Count
                || (count.HasValue && (count < 0 || offset + count.Value > baseList.Count)))
            {
                throw new ArgumentException();
            }

            _baseList = baseList;
            _offset = offset;
            _count = count;

            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            if (createAsImmutable && !IsImmutable)
            {
                _baseList = this.EnumerableToArray();
                _offset = 0;
                _count = null;
                _isImmutable = true;
            }
        }

        public int Count
        {
            get
            {
                return _count ?? (_baseList.Count - _offset);
            }
        }

        public virtual bool IsImmutable
        {
            get
            {
                if (_isImmutable)
                {
                    return true;
                }

                var isImmutable = _baseList as IIsImmutable;
                return !ReferenceEquals(null, isImmutable) && isImmutable.IsImmutable;
            }
        }

        bool ICollection<T>.IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || (_count.HasValue && index >= _count.Value))
                {
                    throw new ArgumentOutOfRangeException();
                }

                return _baseList[index + _offset];
            }
        }

        T IList<T>.this[int index]
        {
            get
            {
                return this[index];
            }

            set
            {
                throw new InvalidOperationException();
            }
        }

        public virtual bool Contains(T item)
        {
            return _baseList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (_offset == 0 && (!_count.HasValue || _count.Value == _baseList.Count))
            {
                _baseList.CopyTo(array, arrayIndex);
                return;
            }

            var endIndex = _count.HasValue ? _offset + _count.Value : _baseList.Count;
            for (int i = _offset; i < endIndex; i++)
            {
                array[arrayIndex++] = _baseList[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_offset == 0 && (!_count.HasValue || _count.Value == _baseList.Count))
            {
                return _baseList.GetEnumerator();
            }

            return GetShiftedEnumerator();
        }

        public virtual int IndexOf(T item)
        {
            return _baseList.IndexOf(item) - _offset;
        }

        public void ThrowIfIsImmutable()
        {
            if (IsImmutable)
            {
                throw new InvalidOperationException(
                    string.Format("The list of the values the type {0} is immutable.", typeof(T).FullName));
            }
        }

        public void ThrowIfIsNotImmutable()
        {
            if (!IsImmutable)
            {
                throw new InvalidOperationException(
                    string.Format("The list of the values the type {0} is not immutable.", typeof(T).FullName));
            }
        }

        void ICollection<T>.Add(T item)
        {
            throw new InvalidOperationException();
        }

        void ICollection<T>.Clear()
        {
            throw new InvalidOperationException();
        }

        void IList<T>.Insert(int index, T item)
        {
            throw new InvalidOperationException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new InvalidOperationException();
        }

        void IList<T>.RemoveAt(int index)
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerator<T> GetShiftedEnumerator()
        {
            var endIndex = _count.HasValue ? _offset + _count.Value : _baseList.Count;
            for (int i = _offset; i < endIndex; i++)
            {
                yield return _baseList[i];
            }
        }
    }

    public class ReadOnlyList<T, TIndex> : ReadOnlyList<T>
    {
        private readonly Func<TIndex, int> _indexConverter;

        public ReadOnlyList(
            bool createAsImmutable,
            IList<T> baseList,
            int offset,
            int? count,
            Func<TIndex, int> indexConverter)
            : base(createAsImmutable, baseList, offset, count)
        {
            _indexConverter = indexConverter;
        }

        public T this[TIndex index]
        {
            get
            {
                return this[_indexConverter(index)];
            }
        }
    }

    public class ReadOnlyList<T, TIndex1, TIndex2> : ReadOnlyList<T>
    {
        private readonly Func<TIndex1, TIndex2, int> _indexConverter;

        public ReadOnlyList(
            bool createAsImmutable,
            IList<T> baseList,
            int offset,
            int? count,
            Func<TIndex1, TIndex2, int> indexConverter)
            : base(createAsImmutable, baseList, offset, count)
        {
            _indexConverter = indexConverter;
        }

        public T this[TIndex1 index1, TIndex2 index2]
        {
            get
            {
                return this[_indexConverter(index1, index2)];
            }
        }
    }
}