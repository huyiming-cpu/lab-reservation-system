
using LabManagementSystem.Service;
using LabReservationApp.DAO;
using LabReservationApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using YourProjectNamespace.DAO;
using YourProjectNamespace.Entity;

namespace LabReservationApp.Service
{
    public class ReservationService
    {
        private readonly EquipmentService _equipmentService = new EquipmentService(); // 新增设备服务依赖
        private readonly ReservationDAO _resDAO = new ReservationDAO();
        private readonly EquipmentDAO _equipmentDAO = new EquipmentDAO();
        /// <summary>
        /// 获取预约记录列表（分页）
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns>预约记录列表</returns>
        public List<Reservation> GetReservations(int pageIndex, int pageSize)
        {
            return _resDAO.GetReservations(pageIndex, pageSize);
        }

        /// <summary>
        /// 获取预约记录总数
        /// </summary>
        /// <returns>记录总数</returns>
        public int GetReservationTotalCount()
        {
            return _resDAO.GetTotalCount();
        }

        /// <summary>
        /// 更新预约状态
        /// </summary>
        /// <param name="reservationId">预约记录ID</param>
        /// <param name="newStatus">新状态</param>
        public void UpdateReservationStatus(long reservationId, byte newStatus)
        {
            _resDAO.UpdateReservationStatus(reservationId, newStatus);
        }

        /// <summary>
        /// 添加预约记录
        /// </summary>
        /// <param name="reservation">预约实体</param>
        public void AddReservation(Reservation reservation)
        {
            try
            {
                _resDAO.AddReservation(reservation);
            }
            catch (Exception ex)
            {
                throw new Exception($"添加预约失败：{ex.Message}", ex);
            }
        }

        public void UpdateReservation(Reservation reservation)
        {
            _resDAO.UpdateReservation1(reservation);
        }

        public Reservation GetReservationById(long reservationId)
        {
            return _resDAO.GetReservationById(reservationId);
        }

        public int GetReservationTotalCountByStatus(string statusFilter)
        {
            return _resDAO.GetTotalCountByStatus(statusFilter);
        }
        public List<Reservation> GetReservationsByStatus1(int pageIndex, int pageSize, string statusFilter)
        {
            return _resDAO.GetReservationsByStatus1(pageIndex, pageSize, statusFilter);
        }

        public string GetEquipmentNamesByLabId1(long labId)
        {
            return _equipmentDAO.GetEquipmentNamesByLabId(labId);
        }
        public List<LabUtilizationStats> GetLabUtilizationStats()
        {
            return _resDAO.GetLabUtilizationStats();
        }
        
       

    }
}