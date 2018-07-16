using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Framework
{
    public interface IExecute
    {
        void Execute(int eventCode, object msgValue);
    }
}
