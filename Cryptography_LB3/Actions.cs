using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_LB3
{
    public enum Actions
    {
        Uknown = 0,
        EncryptTripleDES = 1,
        RSACng = 2,
        DSA = 3,
        SHA384Managed = 4,
        DecryptTripleDES = 5,
        Exit = 6
    }
}
