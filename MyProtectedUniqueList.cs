using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace MyProtectedUniqueList15092020
{
    class MyProtectedUniqueList<T>: IEnumerable<T>
    {
        private List<T> _words;
        string _secret_word;
        public MyProtectedUniqueList(string secret_word )
        {
            _secret_word = secret_word;
            
                _words = new List<T>();
            
        }

        public void Add(T word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("your word is null"); ;
            }
            else if (wordInWords(word))
            {
                throw new InvalidOperationException("the ward that you gave alraedy exist");
            }
            _words.Add(word);
        }


        public void Remove(T word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("your word is null"); ;
            }
            else if (!wordInWords(word))
            {
                throw new ArgumentException("the ward that you gave isnwt exist");
            }
            _words.Remove(word);
        }

        public void RemoveAt(int ind)
        {
            if (ind<0)
            {
                throw new ArgumentOutOfRangeException("index small then zero"); ;
            }
            else if (ind>_words.Count)
            {
                throw new ArgumentOutOfRangeException("ind larger then List size");
            }
            _words.RemoveAt(ind);
        }

        public void Clear(string key)
        {
            if (key == _secret_word)
                _words.Clear();
            else
                throw new AccessViolationException("the key is worng");

        }

        public void Sort(string key)
        {
            if (key == _secret_word)
                _words.Sort();
            else
                throw new AccessViolationException("the key is worng");

        }

        public override string ToString()
        {
            string str = " ";
            _words.ForEach(word => str+= word+" ");
            
            return base.ToString()+str;

        }

        private bool wordInWords(T word) 
        {
            foreach (T _word in _words)
            {
                if (_word.Equals(word))
                    return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _words.GetEnumerator();  
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _words.GetEnumerator();
        }
    }
}
