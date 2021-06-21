using System.Collections;
using System.Collections.Generic;

namespace Dungeons_and_Dragons_Player_Maker {
    public class CircularList<T> : List<T>, IEnumerable<T> {

        public new IEnumerator<T> GetEnumerator() {return new CircularEnumerator<T>(this);}
    }
    class CircularEnumerator<T> : IEnumerator<T> {
        
        private readonly List<T> list;
        int i = 0;
        public T Current => list[i];
        object IEnumerator.Current => this;

        public bool MoveNext() {
            i = (i + 1) % list.Count;
            return true;
        }

        public int getLength() { return list.Count; }

        public CircularEnumerator(List<T> list) { this.list = list; }
        public void Reset() { i = 0; }
        public void Dispose() { }
    }
}
