using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balkezesek
{
    internal class People
    {
        private int id;
        private string name;
        private DateTime elso;
        private DateTime utolso;
        private int suly;
        private int magassag;

        public People(int id, string name, DateTime elso, DateTime utolso, int suly, int magassag)
        {
            this.id = id;
            this.name = name;
            this.elso = elso;
            this.utolso = utolso;
            this.suly = suly;
            this.magassag = magassag;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Elso { get => elso; set => elso = value; }
        public DateTime Utolso { get => utolso; set => utolso = value; }
        public int Suly { get => suly; set => suly = value; }
        public int Magassag { get => magassag; set => magassag = value; }
    }
}
