using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //interface
    public interface IRepository<T, ID> //Repo interface. Using Template. Dynamic Datatype
    //Kokhon kon class hobe ef model er (product class or customer class) , seta bujhanor jonno T.
    //interface er vitorer method gula by default public & abstract hoy.
    //jara ei method gula implement korte chabe, tader override korte obe ei methodderke
    {
        void Add(T e); //entity pass hobe. jokhon jei class dorkar. Add(Product p)/ Add(Customer c)
        List<T> Get();
        T Get(ID id);
        void Edit(T e);
        void Delete(ID id);
    }
}
