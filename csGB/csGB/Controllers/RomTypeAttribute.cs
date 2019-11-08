using System;

namespace csGB.Controllers
{
    internal class CartTypeAttribute : Attribute
    {
        public CartTypeAttribute(int typeCode)
        {
            TypeCode = typeCode;
        }

        public int TypeCode { get; set; }
    }
}