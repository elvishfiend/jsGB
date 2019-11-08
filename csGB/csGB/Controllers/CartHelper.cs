using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB.Controllers
{
    static class CartHelper
    {
        public static ICartController GetCartController(int cartType)
        {
            switch (cartType)
            {
                case 0:
                    return new RomOnly();
                default:
                    throw new NotImplementedException(string.Format("Unknown Cart Type: {0}", cartType));
            }
        }

    }
}
