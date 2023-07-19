using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions;

internal class ValidationException : Exception
{
    public ValidationException(IDictionary<string, string[]> errors)
    {        
    }
}

// TODO