using System.Linq;
using WpfControlLib.Models;
using WpfControlLib.Repositories.Base;
using WpfControlLib.Data;
using System.Collections.Generic;
using System.Diagnostics;

namespace WpfControlLib.Repositories
{
    class GroupsRepository : RepositoryInMemory<Group>
    {
        public GroupsRepository() : base(TestData.Groups) { }

        //public IEnumerable<Group> GetAll()
        //{
        //    return base.GetAll();
        //}

        public void LoadData()
        {
            base.LoadData(TestData.Groups);
        }

        public void Output()
        {
            var items = base.GetAll();
            foreach (var item in items)
            {
                Debug.WriteLine($"Name {item.Name}");
            }
        }

        public void Add(Group group)
        {
            // base.LoadData(TestData.Groups);
            base.Add(group);
        }

        public Group Get(string GroupName) => GetAll().FirstOrDefault(g => g.Name == GroupName);

        public new void Clear() => base.Clear();

        public new bool Remove(Group group) => base.Remove(group);

        protected override void Update(Group Source, Group Destination)
        {
            Destination.Name = Source.Name;
            Destination.Description = Source.Description;
        }

        public void UpdateByType(Group Source, Group Destination)
        {            
            base.Update2(Source, Destination);
        }
        public void UpdateById(int id, Group Destination)
        {
            // int indeItem = GetAll().FirstOrDefault(g => g.Id == id);
            // int indeItem = GetAll().FirstOrDefault(g => g.Id == id).ind;
            base.Update3(id, Destination);
        }
    }
}