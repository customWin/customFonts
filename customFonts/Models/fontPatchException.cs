using System;

namespace customFonts.Models
{
    class fontPatchException : Exception
    {
        public fontPatchException() : base () { }
        public fontPatchException(string message) : base(message) { }
        public fontPatchException(string message, Exception innerException) : base(message, innerException) { }
    }
}
