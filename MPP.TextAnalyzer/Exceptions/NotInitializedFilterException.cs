using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MPP_TextAnalyzer.Exceptions
{
    [System.Serializable]
    public class NotInitializedFilterException : Exception
    {
        public NotInitializedFilterException() {}

        public NotInitializedFilterException(string message) : base(message) { }

        public NotInitializedFilterException(string message, Exception inner) : base(message, inner) { }

        protected NotInitializedFilterException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
