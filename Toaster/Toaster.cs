using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oven
{
    public abstract class Toaster
    {
        public abstract Task Toast(CancellationToken cancellationToken);
    }
}
