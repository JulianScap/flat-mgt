﻿
CREATE LOGIN [fm_user] WITH PASSWORD='fm_user', DEFAULT_DATABASE=[FlatManagement], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

CREATE USER [fm_user] FOR LOGIN [fm_user];
GO
