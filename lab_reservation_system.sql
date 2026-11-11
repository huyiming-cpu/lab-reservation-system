/*
 Navicat Premium Data Transfer

 Source Server         : localhost_3307
 Source Server Type    : MySQL
 Source Server Version : 50525 (5.5.25a)
 Source Host           : localhost:3307
 Source Schema         : lab_reservation_system

 Target Server Type    : MySQL
 Target Server Version : 50525 (5.5.25a)
 File Encoding         : 65001

 Date: 11/11/2026 21:40:22
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for equipment
-- ----------------------------
DROP TABLE IF EXISTS `equipment`;
CREATE TABLE `equipment`  (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '设备ID',
  `lab_id` bigint(20) UNSIGNED NOT NULL COMMENT '所属实验室ID（关联实验室表）',
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '设备名称',
  `model` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '型号',
  `purchase_time` date NULL DEFAULT NULL COMMENT '购置时间',
  `technical_params` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL COMMENT '技术参数',
  `current_status` tinyint(4) NULL DEFAULT NULL COMMENT '状态：1-正常 2-故障 3-维护中',
  `usage_count` int(11) NOT NULL DEFAULT 0 COMMENT '使用次数',
  `fault_count` int(10) UNSIGNED NOT NULL DEFAULT 0 COMMENT '故障次数',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `lab_id`(`lab_id`) USING BTREE,
  CONSTRAINT `equipment_ibfk_1` FOREIGN KEY (`lab_id`) REFERENCES `laboratory` (`id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 61 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci COMMENT = '设备信息表（关联实验室）' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of equipment
-- ----------------------------
INSERT INTO `equipment` VALUES (1, 1, '烧杯', 'Meyd', '2025-07-14', 'vvv', 2, 125, 4);
INSERT INTO `equipment` VALUES (2, 1, '光学显微镜', 'Sshh', '2025-07-12', 'aaaa', 2, 100, 5);
INSERT INTO `equipment` VALUES (3, 2, '示波器', 'Nueheud', '2002-02-02', '1ccc', 1, 0, 0);
INSERT INTO `equipment` VALUES (4, 1, '天平', 'Shbd', '2025-07-14', 'www', 2, 0, 0);
INSERT INTO `equipment` VALUES (5, 1, '搅拌棒', 'Gdhb', '2025-07-01', 'eee', 1, 0, 0);
INSERT INTO `equipment` VALUES (6, 2, '打点计时器', 'Arts, Handicrafts & Sewing', '2024-09-16', 'BC-CE-8534-X', 1, 40, 0);
INSERT INTO `equipment` VALUES (7, 2, '弹簧测力计', 'Books', '2006-07-28', 'DF-CF-5011-N', 1, 30, 0);
INSERT INTO `equipment` VALUES (8, 2, '单摆实验装置', 'Baggage & Travel Equipment', '2019-09-22', 'FC-AE-6472-A', 1, 178, 0);
INSERT INTO `equipment` VALUES (9, 2, '凸透镜', 'Baby', '2021-11-23', 'CB-EC-8658-I', 1, 20, 0);
INSERT INTO `equipment` VALUES (10, 2, '凹透镜', 'Baby', '2009-06-06', 'FE-AF-5331-Z', 1, 105, 0);
INSERT INTO `equipment` VALUES (11, 2, '三棱镜', 'CDs & Vinyl', '2019-04-22', 'DD-CF-6546-Q', 1, 142, 0);
INSERT INTO `equipment` VALUES (12, 2, '多用电表', 'Household & Kitchen Appliances', '2007-08-21', 'BC-CB-7044-E', 1, 163, 0);
INSERT INTO `equipment` VALUES (13, 2, '激光笔', 'Food', '2019-12-19', 'BB-BF-8872-A', 1, 60, 3);
INSERT INTO `equipment` VALUES (14, 2, '电源适配器', 'Appliances', '2013-04-06', 'DC-EE-4528-G', 2, 119, 0);
INSERT INTO `equipment` VALUES (15, 2, '砝码组', 'Handcrafts', '2003-07-30', 'BF-FC-0386-E', 1, 125, 0);
INSERT INTO `equipment` VALUES (16, 2, '小孔成像装置', 'Appliances', '2004-01-19', 'DD-EE-4152-B', 1, 121, 0);
INSERT INTO `equipment` VALUES (17, 2, '滑动变阻器', 'Food', '2019-09-04', 'CC-DD-2242-W', 1, 96, 0);
INSERT INTO `equipment` VALUES (18, 2, '斜面轨道', 'Clothing, Shoes and Jewelry', '2000-12-18', 'DE-EC-7742-G', 1, 62, 0);
INSERT INTO `equipment` VALUES (19, 1, '锥形瓶', 'Baby', '2005-08-10', 'CD-BA-6833-O', 1, 166, 0);
INSERT INTO `equipment` VALUES (20, 1, '容量瓶', 'Baby', '2023-06-26', 'BE-EB-6183-U', 1, 64, 0);
INSERT INTO `equipment` VALUES (21, 1, '分液漏斗', 'Pet Supplies', '2008-10-26', 'FA-EC-8712-R', 1, 78, 0);
INSERT INTO `equipment` VALUES (22, 1, '试管', 'Beauty & Personal Care', '2002-07-23', 'ED-AF-6423-L', 1, 63, 0);
INSERT INTO `equipment` VALUES (23, 1, '试管架', 'Sports & Outdoor', '2022-06-13', 'DF-AC-0692-P', 1, 73, 0);
INSERT INTO `equipment` VALUES (24, 1, '酒精灯', 'Automotive Parts & Accessories', '2002-04-20', 'BB-EB-2583-N', 1, 199, 3);
INSERT INTO `equipment` VALUES (25, 1, '电加热手套', 'Musical Instrument', '2013-11-11', 'DE-BE-2501-U', 1, 139, 0);
INSERT INTO `equipment` VALUES (26, 1, '电子天平', 'Industrial & Scientific Supplies', '2023-04-04', 'AD-BF-1682-N', 1, 158, 0);
INSERT INTO `equipment` VALUES (27, 1, '灭火器', 'Arts, Handicrafts & Sewing', '2016-03-02', 'BE-FE-9340-G', 1, 20, 1);
INSERT INTO `equipment` VALUES (28, 1, '护目镜', 'Beauty', '2015-02-13', 'DA-DE-5957-Y', 1, 3, 0);
INSERT INTO `equipment` VALUES (29, 1, '通风橱', 'Toys & Games', '2015-08-02', 'DA-EC-7101-L', 1, 166, 0);
INSERT INTO `equipment` VALUES (30, 1, '量杯', 'Arts, Handicrafts & Sewing', '2019-05-21', 'DB-AB-9056-X', 1, 199, 0);
INSERT INTO `equipment` VALUES (31, 4, '光学显微镜', 'Video Games', '2004-09-08', 'BA-EA-0614-P', 1, 30, 0);
INSERT INTO `equipment` VALUES (32, 4, '放大镜', 'Pet Supplies', '2008-02-20', 'DF-AD-6981-U', 1, 83, 0);
INSERT INTO `equipment` VALUES (33, 4, '载玻片', 'Sports & Outdoor', '2018-05-06', 'DE-FE-1888-R', 1, 71, 0);
INSERT INTO `equipment` VALUES (34, 4, '盖玻片', 'Pet Supplies', '2006-11-18', 'EE-EE-9526-S', 1, 0, 0);
INSERT INTO `equipment` VALUES (35, 4, '染色剂', 'Others', '2020-02-10', 'DA-DE-5942-E', 1, 92, 0);
INSERT INTO `equipment` VALUES (36, 4, '镊子', 'Industrial & Scientific Supplies', '2025-05-27', 'FA-DE-3725-O', 1, 100, 0);
INSERT INTO `equipment` VALUES (37, 4, '解剖刀', 'Appliances', '2017-08-02', 'AE-EA-6443-E', 1, 169, 0);
INSERT INTO `equipment` VALUES (38, 4, '剪刀', 'Appliances', '2001-11-28', 'AC-ED-4929-E', 1, 124, 0);
INSERT INTO `equipment` VALUES (39, 5, '电阻', 'Automotive Parts & Accessories', '2003-10-08', 'DD-BC-2888-X', 1, 53, 0);
INSERT INTO `equipment` VALUES (40, 5, '二极管', 'Clothing, Shoes and Jewelry', '2009-04-07', 'AB-EE-2744-M', 1, 25, 0);
INSERT INTO `equipment` VALUES (41, 5, '万用表', 'Food', '2015-02-26', 'CB-AB-0470-M', 1, 103, 0);
INSERT INTO `equipment` VALUES (42, 5, '面包板', 'Apps & Games', '2016-12-28', 'FF-DC-8219-I', 1, 44, 0);
INSERT INTO `equipment` VALUES (43, 5, '电路试验台', 'Beauty', '2020-12-08', 'BC-CE-4776-P', 1, 190, 0);
INSERT INTO `equipment` VALUES (44, 5, '游标卡尺', 'Arts, Handicrafts & Sewing', '2004-05-22', 'FD-FD-4838-E', 1, 119, 0);
INSERT INTO `equipment` VALUES (47, 5, '3D打印机', 'Beauty', '2008-09-10', 'DF-ED-5821-R', 1, 15, 0);
INSERT INTO `equipment` VALUES (48, 7, '计算机', 'Film Supplies', '2007-06-10', 'EA-AB-2931-A', 1, 152, 4);
INSERT INTO `equipment` VALUES (49, 7, '主板', 'Others', '2001-12-17', 'FB-AB-8231-W', 1, 50, 0);
INSERT INTO `equipment` VALUES (50, 7, '路由器', 'Health & Baby Care', '2017-02-20', 'BB-FA-4306-W', 1, 23, 0);
INSERT INTO `equipment` VALUES (51, 7, '交换机', 'Clothing, Shoes and Jewelry', '2009-06-13', 'BB-DC-7513-E', 1, 78, 2);
INSERT INTO `equipment` VALUES (52, 9, 'COD检测仪', 'Household & Kitchen Appliances', '2020-05-05', 'DA-AC-0513-H', 1, 10, 0);
INSERT INTO `equipment` VALUES (53, 9, '浊度计', 'Collectibles & Fine Art', '2019-07-07', 'EA-FD-1356-A', 1, 60, 0);
INSERT INTO `equipment` VALUES (54, 9, '气体检测仪', 'CDs & Vinyl', '2003-06-07', 'DF-FA-4725-F', 1, 135, 0);
INSERT INTO `equipment` VALUES (55, 9, '温度表', 'Film Supplies', '2010-12-21', 'CE-BF-5500-B', 1, 85, 0);
INSERT INTO `equipment` VALUES (56, 1, '搅拌棒', 'Dbxy', '2025-07-15', 'YGYhyy', 1, 0, 0);
INSERT INTO `equipment` VALUES (58, 1, '玻璃杯', 'ggg', '2025-07-16', 'dde', 1, 0, 0);
INSERT INTO `equipment` VALUES (59, 112, '王泽荣耀', NULL, NULL, NULL, NULL, 0, 0);
INSERT INTO `equipment` VALUES (60, 112, '手机', 'kkjkj', '2025-08-08', 'nhb', 1, 0, 0);

-- ----------------------------
-- Table structure for laboratory
-- ----------------------------
DROP TABLE IF EXISTS `laboratory`;
CREATE TABLE `laboratory`  (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '实验室ID',
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '实验室名称',
  `location` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '位置（如：实验楼A301）',
  `area` decimal(10, 2) NOT NULL COMMENT '面积（平方米）',
  `equipment_list` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL COMMENT '设备清单（JSON 或文本）',
  `open_start` time NOT NULL COMMENT '开放起始时间',
  `open_end` time NOT NULL COMMENT '开放结束时间',
  `is_enabled` tinyint(1) NOT NULL DEFAULT 1 COMMENT '是否启用',
  `week_day` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '周一' COMMENT '周几开放（如：周一、周二）',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 113 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci COMMENT = '实验室基础信息表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of laboratory
-- ----------------------------
INSERT INTO `laboratory` VALUES (1, '化学实验室', '2教', 200.00, '烧杯 锥形瓶 容量瓶 分液漏斗 酒精灯 灭火器', '09:00:00', '21:30:00', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (2, '物理实验室', '1教', 200.00, '打点计时器 弹簧测力计 多用电表 凸透镜 凹透镜', '10:30:00', '22:30:00', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (3, '麻将实验室', '3教', 100.00, '麻将桌', '08:00:00', '16:00:00', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (4, '生物实验室', '1教', 100.00, ' 光学显微镜 镊子剪刀载玻片 染色剂', '10:00:00', '18:30:00', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (5, '电子电工实验室', '2教', 100.00, ' 面包板 电阻 电容 万用表', '10:57:25', '16:34:18', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (6, '机械工程实验室', '3教', 200.00, ' 游标卡尺 千分尺 硬度计', '13:44:39', '11:32:25', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (7, '计算机硬件实验室', '5教', 100.00, ' 计算机 路由器 交换机 ', '16:13:50', '09:58:24', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (8, '材料分析实验室', '4教', 150.00, NULL, '12:15:11', '09:19:02', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (9, '环境监测实验室', '7教', 150.00, '3D打印机 温度表', '16:05:45', '12:00:45', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (10, '人工智能实验室', '6教', 150.00, NULL, '10:38:45', '17:38:45', 1, '周一');
INSERT INTO `laboratory` VALUES (11, '地质勘探实验室', '1教', 100.00, NULL, '17:11:05', '13:44:42', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (12, '航空航天实验室', '6教', 200.00, NULL, '11:47:02', '15:04:02', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (13, '数学实验室', '7教', 200.00, NULL, '14:00:46', '10:32:31', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (14, '数字媒体实验室', '4教', 100.00, NULL, '13:59:58', '17:43:45', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (15, '赵美婷的实验室', '3教', 150.00, NULL, '17:42:29', '11:29:12', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (16, '徐娅的实验室', '4教', 100.00, NULL, '16:53:50', '16:49:38', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (17, '虎一铭的实验室', '2教', 200.00, NULL, '15:16:19', '17:24:58', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (19, '材料分子实验室', '3教', 150.00, NULL, '13:40:35', '09:22:18', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (20, '艺术实验室', '6教', 100.00, NULL, '11:37:53', '15:32:20', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (21, '体育实验室', '4教', 200.00, NULL, '11:09:34', '13:01:10', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (22, '消防实验室', '1教', 200.00, NULL, '13:01:32', '10:10:16', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (23, '语言学实验室', '7教', 100.00, NULL, '14:03:42', '11:47:45', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (24, '软件实验室', '4教', 100.00, NULL, '09:43:35', '13:46:15', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (26, '智慧实验室', '6教', 150.00, NULL, '12:33:23', '14:30:22', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (27, '电子技术实验室', '3教', 100.00, NULL, '10:56:45', '15:14:32', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (29, '你的实验室', '7教', 200.00, NULL, '11:47:16', '13:24:24', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (30, '他的实验室', '5教', 100.00, NULL, '13:49:34', '11:43:49', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (31, '美食实验室', '7教', 100.00, NULL, '15:56:21', '17:31:20', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (32, '好的实验室', '7教', 150.00, NULL, '15:42:49', '16:25:55', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (33, '坏的实验室', '4教', 200.00, NULL, '11:40:08', '11:45:58', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (34, '公园实验室', '2教', 200.00, NULL, '10:19:18', '11:13:23', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (35, '最好的实验室', '1教', 200.00, NULL, '13:28:20', '11:03:09', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (36, '更好的实验室', '7教', 150.00, NULL, '14:37:41', '12:58:59', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (37, '吃饭实验室', '3教', 150.00, NULL, '11:24:31', '09:44:43', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (38, '睡觉实验室', '6教', 150.00, NULL, '15:00:06', '15:03:53', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (39, '游戏实验室', '5教', 100.00, NULL, '09:47:16', '15:04:29', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (40, '篮球实验室', '2教', 100.00, NULL, '11:43:13', '11:46:41', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (41, '足球实验室', '1教', 200.00, NULL, '16:25:19', '12:37:01', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (42, '羽毛球实验室', '7教', 150.00, NULL, '11:05:57', '15:18:16', 1, '周一-周五');
INSERT INTO `laboratory` VALUES (43, '火锅实验室', '6教', 200.00, NULL, '08:42:58', '18:42:57', 1, '周二');
INSERT INTO `laboratory` VALUES (100, '计算机科学实验室', '5教', 200.00, NULL, '10:26:41', '16:26:41', 1, '周二');
INSERT INTO `laboratory` VALUES (102, '硬件实验室', '5教', 500.00, NULL, '08:00:00', '22:00:00', 1, '周一');
INSERT INTO `laboratory` VALUES (112, '秦海军的实验室', '6教', 500.00, NULL, '08:00:00', '16:00:00', 1, '周二');

-- ----------------------------
-- Table structure for maintenance
-- ----------------------------
DROP TABLE IF EXISTS `maintenance`;
CREATE TABLE `maintenance`  (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '工单ID',
  `equipment_id` bigint(20) UNSIGNED NOT NULL COMMENT '设备ID',
  `equipment_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '设备名称',
  `status` tinyint(4) NOT NULL DEFAULT 1 COMMENT '状态：1-待处理 2-处理中 3-已处理',
  `handler_id` bigint(20) UNSIGNED NULL DEFAULT NULL COMMENT '处理人ID（维修员）',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `equipment_id`(`equipment_id`) USING BTREE,
  INDEX `handler_id`(`handler_id`) USING BTREE,
  CONSTRAINT `maintenance_ibfk_1` FOREIGN KEY (`equipment_id`) REFERENCES `equipment` (`id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `maintenance_ibfk_2` FOREIGN KEY (`handler_id`) REFERENCES `user` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 18 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci COMMENT = '设备维护工单表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of maintenance
-- ----------------------------
INSERT INTO `maintenance` VALUES (1, 2, '光学显微镜', 1, 3);
INSERT INTO `maintenance` VALUES (2, 7, '烧杯', 3, NULL);
INSERT INTO `maintenance` VALUES (3, 20, '激光笔', 3, 3);
INSERT INTO `maintenance` VALUES (4, 37, '计算机', 3, 3);
INSERT INTO `maintenance` VALUES (5, 24, '酒精灯', 3, 3);
INSERT INTO `maintenance` VALUES (6, 24, '酒精灯', 3, 3);
INSERT INTO `maintenance` VALUES (7, 27, '灭火器', 3, 3);
INSERT INTO `maintenance` VALUES (8, 27, '灭火器', 3, 3);
INSERT INTO `maintenance` VALUES (9, 27, '灭火器', 3, 3);
INSERT INTO `maintenance` VALUES (10, 20, '激光笔', 3, 3);
INSERT INTO `maintenance` VALUES (11, 20, '激光笔', 3, 3);
INSERT INTO `maintenance` VALUES (12, 37, '计算机', 3, 15);
INSERT INTO `maintenance` VALUES (13, 55, '交换机', 3, 49);
INSERT INTO `maintenance` VALUES (14, 55, '交换机', 3, 13);
INSERT INTO `maintenance` VALUES (15, 37, '计算机', 3, 8);
INSERT INTO `maintenance` VALUES (16, 24, '酒精灯', 3, 41);
INSERT INTO `maintenance` VALUES (17, 37, '计算机', 3, 6);

-- ----------------------------
-- Table structure for reservation
-- ----------------------------
DROP TABLE IF EXISTS `reservation`;
CREATE TABLE `reservation`  (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '预约记录ID',
  `lab_id` bigint(20) UNSIGNED NOT NULL COMMENT '关联实验室ID',
  `teacher_id` bigint(20) UNSIGNED NOT NULL COMMENT '关联教师用户ID',
  `reserve_date` date NOT NULL COMMENT '预约日期（YYYY-MM-DD）',
  `reserve_start` time NOT NULL COMMENT '预约开始时间（HH:MM:SS）',
  `reserve_end` time NOT NULL COMMENT '预约结束时间（HH:MM:SS）',
  `status` tinyint(4) NOT NULL DEFAULT 0 COMMENT '状态：0-待审核 1-已通过 2-已驳回 3-已签到 4-已签退',
  `signin_time` datetime NULL DEFAULT NULL,
  `signout_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `idx_teacher_status`(`teacher_id`, `status`) USING BTREE,
  INDEX `idx_lab_date`(`lab_id`, `reserve_date`) USING BTREE,
  CONSTRAINT `reservation_ibfk_1` FOREIGN KEY (`lab_id`) REFERENCES `laboratory` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `reservation_ibfk_2` FOREIGN KEY (`teacher_id`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 129 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci COMMENT = '实验室预约主表（最简版）' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of reservation
-- ----------------------------
INSERT INTO `reservation` VALUES (1, 1, 2, '2025-07-13', '19:17:55', '21:14:55', 4, '2025-07-13 19:16:47', '2025-07-13 21:13:47');
INSERT INTO `reservation` VALUES (2, 1, 2, '2025-07-13', '08:16:55', '20:16:55', 4, '2025-07-13 10:54:47', '2025-07-13 15:54:54');
INSERT INTO `reservation` VALUES (3, 2, 2, '2025-07-14', '19:33:55', '20:16:55', 4, '2025-07-14 19:35:25', '2025-07-14 20:10:25');
INSERT INTO `reservation` VALUES (4, 2, 1, '2025-07-14', '19:16:55', '20:16:55', 4, '2025-07-14 19:20:55', '2025-07-14 20:15:14');
INSERT INTO `reservation` VALUES (5, 1, 2, '2025-07-15', '10:00:00', '11:00:00', 4, '2025-07-16 10:31:52', '2025-07-16 15:31:52');
INSERT INTO `reservation` VALUES (120, 5, 2, '2025-07-16', '10:57:25', '12:57:25', 1, NULL, NULL);
INSERT INTO `reservation` VALUES (121, 14, 2, '2025-07-16', '13:59:58', '16:59:58', 1, NULL, NULL);
INSERT INTO `reservation` VALUES (122, 4, 2, '2025-07-16', '10:00:00', '16:00:00', 4, '2025-07-16 12:46:26', '2025-07-16 15:46:26');
INSERT INTO `reservation` VALUES (123, 4, 2, '2025-07-16', '10:00:00', '16:00:00', 1, NULL, NULL);
INSERT INTO `reservation` VALUES (124, 4, 2, '2025-07-16', '10:00:00', '15:00:00', 2, NULL, NULL);
INSERT INTO `reservation` VALUES (125, 4, 2, '2025-07-17', '10:00:00', '15:00:00', 1, NULL, NULL);
INSERT INTO `reservation` VALUES (126, 17, 2, '2025-08-06', '16:16:19', '17:10:19', 2, NULL, NULL);
INSERT INTO `reservation` VALUES (127, 2, 2, '2025-08-08', '11:30:00', '20:30:00', 4, '2025-08-08 12:23:16', '2025-08-08 16:23:16');
INSERT INTO `reservation` VALUES (128, 3, 2, '2025-08-15', '08:00:00', '15:00:00', 0, NULL, NULL);

SET FOREIGN_KEY_CHECKS = 1;
