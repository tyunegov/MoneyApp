using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Other.State
{
    public abstract class AbstractState<R, T>
    {
        public R Create(T model)
        {
            return Create(model);
        }

        public R Success(T model)
        {
            return Success(model);
        }

        public R Success(IEnumerable<T> model)
        {
            return Success(model);
        }

        public R BadRequest(string text = null)
        {
            return BadRequest(text);
        }

        public R NotFound(string text = null)
        {
            return NotFound(text);
        }
    }
}
