using System;
using System.Collections.Generic;
using System.Text;

namespace TeamBuddy.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key):
            base($"{name} ({key}) یافت نشد.")
        {
            
        }
    }
}
