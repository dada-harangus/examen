﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2Expense.Validators
{
    public class ErrorsCollection
    {
        public ErrorsCollection()
        {
            ErrorMessages = new List<string>();
        }

        public string Entity { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
