-- PCBuilder development seed data (SQL Server).
-- Run once on an empty, fully migrated PCBuilder database.
-- Dev logins: headadmin / admin / user, password: Test1234!
-- Hardware specifications are approximate sample data.

SET XACT_ABORT ON;
SET NOCOUNT ON;

BEGIN TRANSACTION;

IF EXISTS (SELECT 1 FROM [AspNetRoles]) OR EXISTS (SELECT 1 FROM [Brands]) OR EXISTS (SELECT 1 FROM [AspNetUsers]) OR EXISTS (SELECT 1 FROM [CPUs])
    THROW 50000, 'Seed aborted: the database already contains data.', 1;

DECLARE @now datetime2 = SYSDATETIME();

-- AspNetRoles
SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] (Id, Name, NormalizedName, ConcurrencyStamp) VALUES
    (1, N'User', N'USER', CONVERT(nvarchar(36), NEWID())),
    (2, N'Admin', N'ADMIN', CONVERT(nvarchar(36), NEWID())),
    (3, N'HeadAdmin', N'HEADADMIN', CONVERT(nvarchar(36), NEWID()));
SET IDENTITY_INSERT [AspNetRoles] OFF;

-- Brands
SET IDENTITY_INSERT [Brands] ON;
INSERT INTO [Brands] (Id, Name, Created, IsDeleted, LastModified) VALUES
    (1, N'Intel', @now, 0, NULL),
    (2, N'AMD', @now, 0, NULL),
    (3, N'NVIDIA', @now, 0, NULL),
    (4, N'ASUS', @now, 0, NULL),
    (5, N'MSI', @now, 0, NULL),
    (6, N'Gigabyte', @now, 0, NULL),
    (7, N'Corsair', @now, 0, NULL),
    (8, N'Kingston', @now, 0, NULL),
    (9, N'G.Skill', @now, 0, NULL),
    (10, N'Crucial', @now, 0, NULL),
    (11, N'Samsung', @now, 0, NULL),
    (12, N'Western Digital', @now, 0, NULL),
    (13, N'Seagate', @now, 0, NULL),
    (14, N'Toshiba', @now, 0, NULL),
    (15, N'NZXT', @now, 0, NULL),
    (16, N'Fractal Design', @now, 0, NULL),
    (17, N'be quiet!', @now, 0, NULL),
    (18, N'Cooler Master', @now, 0, NULL),
    (19, N'Seasonic', @now, 0, NULL),
    (20, N'Lian Li', @now, 0, NULL);
SET IDENTITY_INSERT [Brands] OFF;

-- Series
SET IDENTITY_INSERT [Series] ON;
INSERT INTO [Series] (Id, Name, BrandId, Created, IsDeleted, LastModified) VALUES
    (1, N'Core i3', 1, @now, 0, NULL),
    (2, N'Core i5', 1, @now, 0, NULL),
    (3, N'Core i7', 1, @now, 0, NULL),
    (4, N'Core i9', 1, @now, 0, NULL),
    (5, N'Ryzen 5', 2, @now, 0, NULL),
    (6, N'Ryzen 7', 2, @now, 0, NULL),
    (7, N'Ryzen 9', 2, @now, 0, NULL),
    (8, N'Radeon RX 7000', 2, @now, 0, NULL),
    (9, N'Radeon RX 6000', 2, @now, 0, NULL),
    (10, N'GeForce RTX 40', 3, @now, 0, NULL),
    (11, N'GeForce RTX 30', 3, @now, 0, NULL),
    (12, N'TUF Gaming', 4, @now, 0, NULL),
    (13, N'ROG Strix', 4, @now, 0, NULL),
    (14, N'Dual', 4, @now, 0, NULL),
    (15, N'Prime', 4, @now, 0, NULL),
    (16, N'MAG', 5, @now, 0, NULL),
    (17, N'Ventus', 5, @now, 0, NULL),
    (18, N'Mech', 5, @now, 0, NULL),
    (19, N'Ultra Durable', 6, @now, 0, NULL),
    (20, N'Gaming OC', 6, @now, 0, NULL),
    (21, N'WindForce', 6, @now, 0, NULL),
    (22, N'Vengeance', 7, @now, 0, NULL),
    (23, N'Dominator', 7, @now, 0, NULL),
    (24, N'RM', 7, @now, 0, NULL),
    (25, N'CV', 7, @now, 0, NULL),
    (26, N'4000', 7, @now, 0, NULL),
    (27, N'FURY', 8, @now, 0, NULL),
    (28, N'NV2', 8, @now, 0, NULL),
    (29, N'A400', 8, @now, 0, NULL),
    (30, N'Trident Z5', 9, @now, 0, NULL),
    (31, N'Ripjaws', 9, @now, 0, NULL),
    (32, N'Pro', 10, @now, 0, NULL),
    (33, N'MX500', 10, @now, 0, NULL),
    (34, N'T700', 10, @now, 0, NULL),
    (35, N'EVO', 11, @now, 0, NULL),
    (36, N'PRO', 11, @now, 0, NULL),
    (37, N'Blue', 12, @now, 0, NULL),
    (38, N'Black', 12, @now, 0, NULL),
    (39, N'BarraCuda', 13, @now, 0, NULL),
    (40, N'P300', 14, @now, 0, NULL),
    (41, N'H Series', 15, @now, 0, NULL),
    (42, N'Meshify', 16, @now, 0, NULL),
    (43, N'Pure Base', 17, @now, 0, NULL),
    (44, N'Pure Power', 17, @now, 0, NULL),
    (45, N'MasterBox', 18, @now, 0, NULL),
    (46, N'MWE', 18, @now, 0, NULL),
    (47, N'Focus', 19, @now, 0, NULL),
    (48, N'O11', 20, @now, 0, NULL);
SET IDENTITY_INSERT [Series] OFF;

-- SocketCPUs
SET IDENTITY_INSERT [SocketCPUs] ON;
INSERT INTO [SocketCPUs] (Id, Name, BrandId, Created, IsDeleted, LastModified) VALUES
    (1, N'LGA1700', 1, @now, 0, NULL),
    (2, N'AM4', 2, @now, 0, NULL),
    (3, N'AM5', 2, @now, 0, NULL);
SET IDENTITY_INSERT [SocketCPUs] OFF;

-- SlotInterfaces
SET IDENTITY_INSERT [SlotInterfaces] ON;
INSERT INTO [SlotInterfaces] (Id, Name, Created, IsDeleted, LastModified) VALUES
    (1, N'SATA III', @now, 0, NULL),
    (2, N'M.2 NVMe PCIe 3.0 x4', @now, 0, NULL),
    (3, N'M.2 NVMe PCIe 4.0 x4', @now, 0, NULL),
    (4, N'M.2 NVMe PCIe 5.0 x4', @now, 0, NULL),
    (5, N'PCIe 3.0 x16', @now, 0, NULL),
    (6, N'PCIe 4.0 x16', @now, 0, NULL),
    (7, N'PCIe 4.0 x8', @now, 0, NULL),
    (8, N'PCIe 5.0 x16', @now, 0, NULL);
SET IDENTITY_INSERT [SlotInterfaces] OFF;

-- RamSpeeds
SET IDENTITY_INSERT [RamSpeeds] ON;
INSERT INTO [RamSpeeds] (Id, Standard, Freq, Created, IsDeleted, LastModified) VALUES
    (1, N'DDR4', 2666, @now, 0, NULL),
    (2, N'DDR4', 3200, @now, 0, NULL),
    (3, N'DDR4', 3600, @now, 0, NULL),
    (4, N'DDR5', 4800, @now, 0, NULL),
    (5, N'DDR5', 5200, @now, 0, NULL),
    (6, N'DDR5', 5600, @now, 0, NULL),
    (7, N'DDR5', 6000, @now, 0, NULL),
    (8, N'DDR5', 6400, @now, 0, NULL);
SET IDENTITY_INSERT [RamSpeeds] OFF;

-- CPUs
SET IDENTITY_INSERT [CPUs] ON;
INSERT INTO [CPUs] (Id, Name, Model, Cores, Threads, MinFreq, MaxFreq, L2Cache, L3Cache, MaxRam, IsAPU, Technology, TDP, SeriesId, SocketCpuId, Description, Created, IsDeleted, LastModified) VALUES
    (1, N'Intel Core i3-12100F', N'BX8071512100F', 4, 8, 3.3, 4.3, 5, 12, 128, 0, 10, 58, 1, 1, N'Budget 4-core processor for LGA1700 without integrated graphics.', @now, 0, NULL),
    (2, N'Intel Core i5-13600K', N'BX8071513600K', 14, 20, 3.5, 5.1, 20, 24, 128, 0, 10, 125, 2, 1, N'Hybrid 6P + 8E core processor for gaming and productivity.', @now, 0, NULL),
    (3, N'Intel Core i7-13700K', N'BX8071513700K', 16, 24, 3.4, 5.4, 24, 30, 128, 0, 10, 125, 3, 1, N'Hybrid 8P + 8E core processor with high single-thread performance.', @now, 0, NULL),
    (4, N'Intel Core i9-13900K', N'BX8071513900K', 24, 32, 3, 5.8, 32, 36, 128, 0, 10, 125, 4, 1, N'Flagship 8P + 16E core processor for LGA1700.', @now, 0, NULL),
    (5, N'AMD Ryzen 5 5600X', N'100-100000065BOX', 6, 12, 3.7, 4.6, 3, 32, 128, 0, 7, 65, 5, 2, N'Popular 6-core Zen 3 processor for AM4.', @now, 0, NULL),
    (6, N'AMD Ryzen 7 5800X3D', N'100-100000651WOF', 8, 16, 3.4, 4.5, 4, 96, 128, 0, 7, 105, 6, 2, N'Zen 3 processor with 3D V-Cache aimed at gaming.', @now, 0, NULL),
    (7, N'AMD Ryzen 5 5600G', N'100-100000252BOX', 6, 12, 3.9, 4.4, 3, 16, 128, 1, 7, 65, 5, 2, N'6-core APU with integrated Radeon graphics for AM4.', @now, 0, NULL),
    (8, N'AMD Ryzen 5 7600X', N'100-100000593WOF', 6, 12, 4.7, 5.3, 6, 32, 128, 0, 5, 105, 5, 3, N'6-core Zen 4 processor for AM5 with DDR5 support.', @now, 0, NULL),
    (9, N'AMD Ryzen 7 7800X3D', N'100-100000910WOF', 8, 16, 4.2, 5, 8, 96, 128, 0, 5, 120, 6, 3, N'Zen 4 processor with 3D V-Cache aimed at gaming.', @now, 0, NULL),
    (10, N'AMD Ryzen 9 7950X', N'100-100000514WOF', 16, 32, 4.5, 5.7, 16, 64, 128, 0, 5, 170, 7, 3, N'16-core Zen 4 processor for demanding workloads.', @now, 0, NULL);
SET IDENTITY_INSERT [CPUs] OFF;

-- RAMs
SET IDENTITY_INSERT [RAMs] ON;
INSERT INTO [RAMs] (Id, Name, Model, Capacity, NoELements, Latency, MemorySpeedId, SeriesId, Description, Created, IsDeleted, LastModified) VALUES
    (1, N'Corsair Vengeance LPX 16GB (2x8GB) DDR4-3200', N'CMK16GX4M2B3200C16', 16, 2, N'CL16', 2, 22, N'Low-profile DDR4 kit.', @now, 0, NULL),
    (2, N'Corsair Vengeance LPX 32GB (2x16GB) DDR4-3600', N'CMK32GX4M2D3600C18', 32, 2, N'CL18', 3, 22, N'Low-profile DDR4 kit.', @now, 0, NULL),
    (3, N'Kingston FURY Beast 16GB (2x8GB) DDR4-3200', N'KF432C16BBK2/16', 16, 2, N'CL16', 2, 27, N'DDR4 kit with Plug N Play overclocking.', @now, 0, NULL),
    (4, N'G.Skill Ripjaws V 16GB (2x8GB) DDR4-3600', N'F4-3600C16D-16GVKC', 16, 2, N'CL16', 3, 31, N'DDR4 kit for AMD and Intel platforms.', @now, 0, NULL),
    (5, N'Corsair Vengeance 32GB (2x16GB) DDR5-5600', N'CMK32GX5M2B5600C36', 32, 2, N'CL36', 6, 22, N'DDR5 kit.', @now, 0, NULL),
    (6, N'Kingston FURY Beast 32GB (2x16GB) DDR5-5200', N'KF552C40BBK2-32', 32, 2, N'CL40', 5, 27, N'DDR5 kit.', @now, 0, NULL),
    (7, N'G.Skill Trident Z5 RGB 32GB (2x16GB) DDR5-6000', N'F5-6000J3636F16GX2-TZ5RK', 32, 2, N'CL36', 7, 30, N'DDR5 kit with RGB lighting.', @now, 0, NULL),
    (8, N'Crucial Pro 32GB (2x16GB) DDR5-5600', N'CP2K16G56C46U5', 32, 2, N'CL46', 6, 32, N'DDR5 kit.', @now, 0, NULL),
    (9, N'Corsair Dominator Platinum RGB 64GB (2x32GB) DDR5-6000', N'CMT64GX5M2B6000C30', 64, 2, N'CL30', 7, 23, N'High-capacity DDR5 kit with RGB lighting.', @now, 0, NULL);
SET IDENTITY_INSERT [RAMs] OFF;

-- Motherboards
SET IDENTITY_INSERT [Motherboards] ON;
INSERT INTO [Motherboards] (Id, Name, Model, SeriesId, SocketCpuId, Chipset, MaxMemory, SATASlots, M2Slots, RamSlots, CaseSizeId, CaseSize, Description, Created, IsDeleted, LastModified) VALUES
    (1, N'MSI MAG B550 TOMAHAWK', N'MAG B550 TOMAHAWK', 16, 2, N'B550', 128, 6, 2, 4, 1, 1, N'ATX board for AM4 with DDR4 support.', @now, 0, NULL),
    (2, N'ASUS TUF GAMING B550-PLUS', N'TUF GAMING B550-PLUS', 12, 2, N'B550', 128, 6, 2, 4, 1, 1, N'ATX board for AM4 with DDR4 support.', @now, 0, NULL),
    (3, N'ASUS ROG STRIX B550-I GAMING', N'ROG STRIX B550-I GAMING', 13, 2, N'B550', 64, 4, 2, 2, 3, 3, N'Mini-ITX board for AM4 with DDR4 support.', @now, 0, NULL),
    (4, N'ASUS ROG STRIX B650-A GAMING WIFI', N'ROG STRIX B650-A GAMING WIFI', 13, 3, N'B650', 192, 4, 3, 4, 1, 1, N'ATX board for AM5 with DDR5 support.', @now, 0, NULL),
    (5, N'Gigabyte B650M DS3H', N'B650M DS3H', 19, 3, N'B650', 192, 4, 2, 4, 2, 2, N'Micro-ATX board for AM5 with DDR5 support.', @now, 0, NULL),
    (6, N'ASUS PRIME B760M-A D4', N'PRIME B760M-A D4', 15, 1, N'B760', 128, 4, 2, 4, 2, 2, N'Micro-ATX board for LGA1700 with DDR4 support.', @now, 0, NULL),
    (7, N'MSI MAG B760 TOMAHAWK WIFI DDR4', N'MAG B760 TOMAHAWK WIFI DDR4', 16, 1, N'B760', 128, 4, 3, 4, 1, 1, N'ATX board for LGA1700 with DDR4 support.', @now, 0, NULL);
SET IDENTITY_INSERT [Motherboards] OFF;

-- MotherboardMemories
INSERT INTO [MotherboardMemories] (MemoryId, MotherBoardId) VALUES
    (1, 1),
    (2, 1),
    (3, 1),
    (1, 2),
    (2, 2),
    (3, 2),
    (1, 3),
    (2, 3),
    (3, 3),
    (4, 4),
    (5, 4),
    (6, 4),
    (7, 4),
    (8, 4),
    (4, 5),
    (5, 5),
    (6, 5),
    (7, 5),
    (8, 5),
    (1, 6),
    (2, 6),
    (3, 6),
    (1, 7),
    (2, 7),
    (3, 7);

-- Cases
SET IDENTITY_INSERT [Cases] ON;
INSERT INTO [Cases] (Id, Name, Model, Height, Width, Deepth, CaseSizeId, CaseSize, SeriesId, Description, Created, IsDeleted, LastModified) VALUES
    (1, N'NZXT H510', N'CA-H510B-B1', 460, 210, 428, 1, 1, 41, N'Compact ATX mid tower.', @now, 0, NULL),
    (2, N'Fractal Design Meshify C', N'FD-CA-MESH-C-BKO', 440, 212, 453, 1, 1, 42, N'Compact ATX mid tower with a mesh front panel.', @now, 0, NULL),
    (3, N'Corsair 4000D Airflow', N'CC-9011200-WW', 453, 230, 466, 1, 1, 26, N'ATX mid tower focused on airflow.', @now, 0, NULL),
    (4, N'Cooler Master MasterBox NR200P', N'MCB-NR200P-KGNN-S00', 376, 185, 292, 3, 3, 45, N'Small form factor Mini-ITX case.', @now, 0, NULL),
    (5, N'be quiet! Pure Base 500', N'BG034', 463, 231, 450, 1, 1, 43, N'Quiet ATX mid tower.', @now, 0, NULL),
    (6, N'Lian Li O11 Dynamic EVO', N'O11DEX', 465, 285, 459, 0, 0, 48, N'Dual-chamber E-ATX mid tower.', @now, 0, NULL),
    (7, N'Cooler Master MasterBox Q300L', N'MCB-Q300L-KANN-S00', 404, 230, 387, 2, 2, 45, N'Compact Micro-ATX case.', @now, 0, NULL);
SET IDENTITY_INSERT [Cases] OFF;

-- PSUs
SET IDENTITY_INSERT [PSUs] ON;
INSERT INTO [PSUs] (Id, Name, Model, standard, Power, Fans, HasPFC, MainConnPins, PCIExpressConn, HasSLI, HasCrossFire, Voltage, Freq, Connectors, Description, Dimensions, SeriesId, Created, IsDeleted, LastModified) VALUES
    (1, N'Corsair CV550', N'CP-9020210-EU', N'80 PLUS Bronze', 550, N'1x 120 mm', 1, N'24-pin (20+4)', N'2x 6+2-pin', 0, 0, N'100-240 V', N'50-60 Hz', N'6x SATA, 3x Molex, 1x 4+4-pin CPU', N'Entry-level non-modular PSU.', N'8.6 x 15 x 14', 25, @now, 0, NULL),
    (2, N'Cooler Master MWE 650 Bronze V2', N'MPE-6501-ACAAB-EU', N'80 PLUS Bronze', 650, N'1x 120 mm', 1, N'24-pin (20+4)', N'2x 6+2-pin', 1, 1, N'100-240 V', N'50-60 Hz', N'6x SATA, 3x Molex, 1x 4+4-pin CPU', N'Non-modular PSU for mainstream builds.', N'8.6 x 15 x 14', 46, @now, 0, NULL),
    (3, N'be quiet! Pure Power 11 600W', N'BN294', N'80 PLUS Gold', 600, N'1x 120 mm', 1, N'24-pin (20+4)', N'2x 6+2-pin', 1, 1, N'100-240 V', N'50-60 Hz', N'6x SATA, 3x Molex, 1x 4+4-pin CPU', N'Quiet non-modular PSU.', N'8.6 x 15 x 14', 44, @now, 0, NULL),
    (4, N'Seasonic FOCUS GX-750', N'SSR-750FX', N'80 PLUS Gold', 750, N'1x 120 mm', 1, N'24-pin (20+4)', N'4x 6+2-pin', 1, 1, N'100-240 V', N'50-60 Hz', N'8x SATA, 4x Molex, 2x 4+4-pin CPU', N'Fully modular PSU.', N'8.6 x 15 x 14', 47, @now, 0, NULL),
    (5, N'Corsair RM750e', N'CP-9020248-EU', N'80 PLUS Gold', 750, N'1x 135 mm', 1, N'24-pin (20+4)', N'4x 6+2-pin', 1, 1, N'100-240 V', N'50-60 Hz', N'8x SATA, 4x Molex, 2x 4+4-pin CPU', N'Fully modular, low-noise PSU.', N'8.6 x 15 x 14', 24, @now, 0, NULL),
    (6, N'Corsair RM1000x', N'CP-9020201-EU', N'80 PLUS Gold', 1000, N'1x 135 mm', 1, N'24-pin (20+4)', N'6x 6+2-pin', 1, 1, N'100-240 V', N'50-60 Hz', N'12x SATA, 4x Molex, 2x 4+4-pin CPU', N'Fully modular high-wattage PSU.', N'8.6 x 15 x 14', 24, @now, 0, NULL);
SET IDENTITY_INSERT [PSUs] OFF;

-- GPUs
SET IDENTITY_INSERT [GPUs] ON;
INSERT INTO [GPUs] (Id, Name, SeriesId, ChipsetSeriesId, CoresQuantity, CoreClock, MemorySize, MemoryInterface, MemoryType, DirectX, OpenGL, TDP, RecommendedPsuPower, Length, Description, Created, IsDeleted, LastModified) VALUES
    (1, N'ASUS Dual GeForce RTX 3060 12GB', 14, 11, 3584, N'1777', 12, 192, N'GDDR6', N'12 Ultimate', 4.6, 170, 550, 200, N'GeForce RTX 30 graphics card with 12 GB GDDR6.', @now, 0, NULL),
    (2, N'MSI GeForce RTX 4060 Ventus 2X Black 8GB', 17, 10, 3072, N'2460', 8, 128, N'GDDR6', N'12 Ultimate', 4.6, 115, 550, 199, N'GeForce RTX 40 graphics card with 8 GB GDDR6.', @now, 0, NULL),
    (3, N'MSI GeForce RTX 4060 Ti Ventus 2X Black 8GB', 17, 10, 4352, N'2535', 8, 128, N'GDDR6', N'12 Ultimate', 4.6, 160, 550, 199, N'GeForce RTX 40 graphics card with 8 GB GDDR6.', @now, 0, NULL),
    (4, N'Gigabyte GeForce RTX 4070 WINDFORCE 12GB', 21, 10, 5888, N'2475', 12, 192, N'GDDR6X', N'12 Ultimate', 4.6, 200, 650, 261, N'GeForce RTX 40 graphics card with 12 GB GDDR6X.', @now, 0, NULL),
    (5, N'ASUS TUF Gaming GeForce RTX 4070 Ti 12GB', 12, 10, 7680, N'2610', 12, 192, N'GDDR6X', N'12 Ultimate', 4.6, 285, 700, 301, N'GeForce RTX 40 graphics card with 12 GB GDDR6X.', @now, 0, NULL),
    (6, N'MSI GeForce RTX 4080 16GB Ventus 3X', 17, 10, 9728, N'2505', 16, 256, N'GDDR6X', N'12 Ultimate', 4.6, 320, 750, 322, N'GeForce RTX 40 graphics card with 16 GB GDDR6X.', @now, 0, NULL),
    (7, N'ASUS ROG Strix GeForce RTX 4090 24GB', 13, 10, 16384, N'2520', 24, 384, N'GDDR6X', N'12 Ultimate', 4.6, 450, 850, 358, N'GeForce RTX 40 graphics card with 24 GB GDDR6X.', @now, 0, NULL),
    (8, N'MSI Radeon RX 7600 Mech 2X Classic 8GB', 18, 8, 2048, N'2655', 8, 128, N'GDDR6', N'12 Ultimate', 4.6, 165, 550, 235, N'Radeon RX 7000 graphics card with 8 GB GDDR6.', @now, 0, NULL),
    (9, N'ASUS TUF Gaming Radeon RX 7800 XT 16GB', 12, 8, 3840, N'2430', 16, 256, N'GDDR6', N'12 Ultimate', 4.6, 263, 700, 305, N'Radeon RX 7000 graphics card with 16 GB GDDR6.', @now, 0, NULL),
    (10, N'Gigabyte Radeon RX 7900 XTX Gaming OC 24GB', 20, 8, 6144, N'2500', 24, 384, N'GDDR6', N'12 Ultimate', 4.6, 355, 800, 331, N'Radeon RX 7000 graphics card with 24 GB GDDR6.', @now, 0, NULL);
SET IDENTITY_INSERT [GPUs] OFF;

-- SlotGpus
INSERT INTO [SlotGpus] (SlotId, GpuId) VALUES
    (6, 1),
    (7, 2),
    (7, 3),
    (6, 4),
    (6, 5),
    (6, 6),
    (6, 7),
    (7, 8),
    (6, 9),
    (6, 10);

-- Hdds
SET IDENTITY_INSERT [Hdds] ON;
INSERT INTO [Hdds] (Id, Name, Model, Description, Capacity, Rpm, Cache, SlotInterfaceId, SeriesId, Created, IsDeleted, LastModified) VALUES
    (1, N'WD Blue 1TB', N'WD10EZEX', N'1 TB 7200 RPM SATA hard drive.', 1000, 7200, 64, 1, 37, @now, 0, NULL),
    (2, N'WD Blue 2TB', N'WD20EZBX', N'2 TB 7200 RPM SATA hard drive.', 2000, 7200, 256, 1, 37, @now, 0, NULL),
    (3, N'Seagate BarraCuda 2TB', N'ST2000DM008', N'2 TB 7200 RPM SATA hard drive.', 2000, 7200, 256, 1, 39, @now, 0, NULL),
    (4, N'Seagate BarraCuda 4TB', N'ST4000DM004', N'4 TB 5400 RPM SATA hard drive.', 4000, 5400, 256, 1, 39, @now, 0, NULL),
    (5, N'Toshiba P300 2TB', N'HDWD120EZSTA', N'2 TB 7200 RPM SATA hard drive.', 2000, 7200, 64, 1, 40, @now, 0, NULL);
SET IDENTITY_INSERT [Hdds] OFF;

-- Ssds
SET IDENTITY_INSERT [Ssds] ON;
INSERT INTO [Ssds] (Id, Name, Model, Description, Capacity, MaxRead, MaxWrite, SlotInterfaceId, SeriesId, Created, IsDeleted, LastModified) VALUES
    (1, N'Samsung 870 EVO 500GB', N'MZ-77E500B/EU', N'SATA III solid state drive.', 500, 560, 530, 1, 35, @now, 0, NULL),
    (2, N'Crucial MX500 1TB', N'CT1000MX500SSD1', N'SATA III solid state drive.', 1000, 560, 510, 1, 33, @now, 0, NULL),
    (3, N'Kingston A400 480GB', N'SA400S37/480G', N'SATA III solid state drive.', 480, 500, 450, 1, 29, @now, 0, NULL),
    (4, N'WD Blue SN570 1TB', N'WDS100T3B0C', N'M.2 NVMe PCIe 3.0 x4 solid state drive.', 1000, 3500, 3000, 2, 37, @now, 0, NULL),
    (5, N'Kingston NV2 1TB', N'SNV2S/1000G', N'M.2 NVMe PCIe 4.0 x4 solid state drive.', 1000, 3500, 2100, 3, 28, @now, 0, NULL),
    (6, N'Samsung 980 PRO 1TB', N'MZ-V8P1T0BW', N'M.2 NVMe PCIe 4.0 x4 solid state drive.', 1000, 7000, 5000, 3, 36, @now, 0, NULL),
    (7, N'Samsung 990 PRO 1TB', N'MZ-V9P1T0BW', N'M.2 NVMe PCIe 4.0 x4 solid state drive.', 1000, 7450, 6900, 3, 36, @now, 0, NULL),
    (8, N'WD Black SN850X 1TB', N'WDS100T2X0E', N'M.2 NVMe PCIe 4.0 x4 solid state drive.', 1000, 7300, 6300, 3, 38, @now, 0, NULL),
    (9, N'Crucial T700 1TB', N'CT1000T700SSD3', N'M.2 NVMe PCIe 5.0 x4 solid state drive.', 1000, 11700, 9500, 4, 34, @now, 0, NULL);
SET IDENTITY_INSERT [Ssds] OFF;

-- AspNetUsers
SET IDENTITY_INSERT [AspNetUsers] ON;
INSERT INTO [AspNetUsers] (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, Created, IsDeleted, LastModified) VALUES
    (1, N'headadmin', N'HEADADMIN', N'headadmin@pcbuilder.local', N'HEADADMIN@PCBUILDER.LOCAL', 1, N'AQAAAAIAAYagAAAAEMnijNbxamOa97JSFX63nfogRAOPFHzGoJ6zNALyjvSWC7u+G6MwjXsLe95NIhc7/g==', CONVERT(nvarchar(36), NEWID()), CONVERT(nvarchar(36), NEWID()), 0, 0, 0, 0, 0, @now, 0, NULL),
    (2, N'admin', N'ADMIN', N'admin@pcbuilder.local', N'ADMIN@PCBUILDER.LOCAL', 1, N'AQAAAAIAAYagAAAAEC1oKpfs1sI5hO6FNVSgGaiZTnUpI/XJtvNSVNkczdCBOZV2VDAJiMDE33Ek3FSo1g==', CONVERT(nvarchar(36), NEWID()), CONVERT(nvarchar(36), NEWID()), 0, 0, 0, 0, 0, @now, 0, NULL),
    (3, N'user', N'USER', N'user@pcbuilder.local', N'USER@PCBUILDER.LOCAL', 1, N'AQAAAAIAAYagAAAAEEdQBJr61X+4R0L8fIRhDLwMSnz6ondLtlNQZvwAydCwWExXd3Jn1FW5ZhBHI4ph8A==', CONVERT(nvarchar(36), NEWID()), CONVERT(nvarchar(36), NEWID()), 0, 0, 0, 0, 0, @now, 0, NULL);
SET IDENTITY_INSERT [AspNetUsers] OFF;

-- AspNetUserRoles
INSERT INTO [AspNetUserRoles] (UserId, RoleId) VALUES
    (1, 3),
    (2, 2),
    (3, 1);

-- Computers
SET IDENTITY_INSERT [Computers] ON;
INSERT INTO [Computers] (Id, UserId, Name, CaseId, CpuId, MotherboardId, RamMemoryId, PsuId, GpuId, Created, IsDeleted, LastModified) VALUES
    (1, 3, N'Budget 1080p (AM4)', 1, 5, 1, 1, 2, 1, @now, 0, NULL),
    (2, 3, N'Gaming 1440p (AM5)', 3, 8, 4, 5, 5, 4, @now, 0, NULL),
    (3, 3, N'Intel Midrange (LGA1700)', 2, 2, 7, 2, 4, 3, @now, 0, NULL),
    (4, 3, N'Compact ITX (AM4)', 4, 6, 3, 4, 4, 8, @now, 0, NULL),
    (5, 2, N'Workstation (AM5)', 6, 10, 4, 9, 6, 7, @now, 0, NULL);
SET IDENTITY_INSERT [Computers] OFF;

-- ComputerHdds
INSERT INTO [ComputerHdds] (ComputerId, HddId) VALUES
    (1, 1),
    (2, 3),
    (5, 4);

-- ComputerSsds
INSERT INTO [ComputerSsds] (ComputerId, SsdId) VALUES
    (1, 4),
    (2, 7),
    (3, 5),
    (3, 2),
    (4, 8),
    (5, 7),
    (5, 8);

COMMIT TRANSACTION;

SELECT t.[Table], t.[Rows] FROM (VALUES
    (N'AspNetRoles', (SELECT COUNT(*) FROM [AspNetRoles])),
    (N'Brands', (SELECT COUNT(*) FROM [Brands])),
    (N'Series', (SELECT COUNT(*) FROM [Series])),
    (N'SocketCPUs', (SELECT COUNT(*) FROM [SocketCPUs])),
    (N'SlotInterfaces', (SELECT COUNT(*) FROM [SlotInterfaces])),
    (N'RamSpeeds', (SELECT COUNT(*) FROM [RamSpeeds])),
    (N'CPUs', (SELECT COUNT(*) FROM [CPUs])),
    (N'RAMs', (SELECT COUNT(*) FROM [RAMs])),
    (N'Motherboards', (SELECT COUNT(*) FROM [Motherboards])),
    (N'MotherboardMemories', (SELECT COUNT(*) FROM [MotherboardMemories])),
    (N'Cases', (SELECT COUNT(*) FROM [Cases])),
    (N'PSUs', (SELECT COUNT(*) FROM [PSUs])),
    (N'GPUs', (SELECT COUNT(*) FROM [GPUs])),
    (N'SlotGpus', (SELECT COUNT(*) FROM [SlotGpus])),
    (N'Hdds', (SELECT COUNT(*) FROM [Hdds])),
    (N'Ssds', (SELECT COUNT(*) FROM [Ssds])),
    (N'AspNetUsers', (SELECT COUNT(*) FROM [AspNetUsers])),
    (N'AspNetUserRoles', (SELECT COUNT(*) FROM [AspNetUserRoles])),
    (N'Computers', (SELECT COUNT(*) FROM [Computers])),
    (N'ComputerHdds', (SELECT COUNT(*) FROM [ComputerHdds])),
    (N'ComputerSsds', (SELECT COUNT(*) FROM [ComputerSsds]))
) AS t([Table], [Rows]);
