using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Personel: IEntity   

    //Personel DB.deki "Employees" e karşılık
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
