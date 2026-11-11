using LabReservationApp.DAO;
using LabReservationApp.Entity; 
using System;
using System.Collections.Generic;
using YourProjectNamespace.DAO;
using YourProjectNamespace.Entity;

namespace LabManagementSystem.Service
{
    public class EquipmentService
    {
        private EquipmentDAO _equipmentDAO = new EquipmentDAO();

        // 分页查询设备（直接调用 DAO）
        public List<Equipment> GetEquipmentList(int pageIndex, int pageSize)
        {
            return _equipmentDAO.GetEquipmentList(pageIndex, pageSize);
        }

        // 获取设备总数
        public int GetTotalCount()
        {
            return _equipmentDAO.GetTotalCount();
        }

        // 保存设备
        public bool SaveEquipment(Equipment equipment)
        {
            // 基础校验
            if (string.IsNullOrWhiteSpace(equipment.Name))
                throw new ArgumentException("设备名称不能为空");

            // 状态校验（1-正常/2-故障/3-维护中，其他值拒绝）
            if (equipment.CurrentStatus < 1 || equipment.CurrentStatus > 3)
                throw new ArgumentException("设备状态值非法，仅支持 1-正常、2-故障、3-维护中");

            return _equipmentDAO.SaveEquipment(equipment);
        }

    
        public bool DeleteEquipment(long id)
        {
            
            return _equipmentDAO.DeleteEquipment(id);
        }

        public List<Equipment> GetEquipmentsByLabId1(long labId, int status = 1)
        {
            return _equipmentDAO.GetEquipmentsByLabId(labId, status);
        }

       
        public void UpdateEquipmentStatus1(long equipmentId, int newStatus)
        {
            _equipmentDAO.UpdateEquipmentStatus(equipmentId, newStatus);
        }


        public string GetLabNameById(long labId)
        {
            
            return new LaboratoryDAO().GetLaboratoryNameById(labId);
        }


    }
}