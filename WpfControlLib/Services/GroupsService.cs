using System;
using System.Collections.Generic;
using System.Text;
using WpfControlLib.Repositories;
using WpfControlLib.Models;

namespace WpfControlLib.Services
{
    class GroupsService
    {
        GroupsRepository GroupsRepository;

        public GroupsService()
        {
            GroupsRepository = new GroupsRepository();
        }


        public IEnumerable<Group> GetAll()
        {
            return GroupsRepository.GetAll();
        }

        public void LoadData()
        {
            GroupsRepository.LoadData();
        }

        public void Output()
        {
            GroupsRepository.Output();
        }

        public void Add(Group group)
        {
            // base.LoadData(TestData.Groups);
            // base.Add(group);
            GroupsRepository.Add(group);
        }

        
        /// Update
        /// === === === === === === ===
        #region Update        
        public void UpdateByType(Group Source, Group Destination)
        {
            GroupsRepository.UpdateByType(Source, Destination);
        }
        public void UpdateById(int id, Group Destination)
        {
            // int indeItem = GetAll().FirstOrDefault(g => g.Id == id);
            // int indeItem = GetAll().FirstOrDefault(g => g.Id == id).ind;
            // base.Update3(id, Destination);
            GroupsRepository.UpdateById(id, Destination);
        }
        #endregion

        
        /// Delete
        ///  === === === === === === ===

        #region Delete
        public void DeleteAll()
        {
            GroupsRepository.Clear();
        }

        public void DeleteSelected(Group group)
        {
            GroupsRepository.Remove(group);
        }

        #endregion




    }
}
