CREATE DATABASE APPLICATION
USE APPLICATION

-------------------table creation------------------
CREATE TABLE [DBO].[APPLICATION](
appID int identity(1,1) primary key,
appName Nvarchar(200),
appDesp Nvarchar(400),
isDeleted bit
)
insert into [DBO].[APPLICATION] values('Myntra','Good products','')
insert into [DBO].[APPLICATION] values('Koovs','Famous for Western wear','')


SELECT *FROM [DBO].[APPLICATION]
drop table [DBO].[APPLICATION]

--------------insert--------------------------
create proc [DBO].[proc_insertApp](@appName Nvarchar(200),@appDesp Nvarchar(400),@isDeleted bit)
as
begin
 insert into APPLICATION values(@appName,@appDesp,@isDeleted)
end
execute [DBO].[proc_insertApp] 'Udemy','Good Learning Website',1
drop procedure [DBO].[proc_insertApp]
SELECT *FROM [DBO].[APPLICATION]
--------------update----------------------------------
create proc [DBO].[proc_updateApp](@appId int,@appname Nvarchar(200),@appDesp Nvarchar(400))
as
begin
update APPLICATION set appName=@appName,appDesp=@appDesp where appId=@appId
end
execute [DBO].[proc_updateApp] 3,'Udemy','Best Website'
drop procedure [DBO].[proc_updateApp]
SELECT *FROM [DBO].[APPLICATION]
---------------------------read-------------------------
create proc [DBO].[proc_readapp](@appId int)
as
begin
select appId,appName,appDesp
from [DBO].[APPLICATION]
where appId=@appId
end
execute [DBO].[proc_readapp] @appId=2
SELECT *FROM [DBO].[APPLICATION]

----------------------------------soft delete------------------------
create proc [DBO].[softDelete](@appId int,@isDeleted bit)
as
begin
update APPLICATION set isDeleted=1 where appId=@appId
end
execute [DBO].[softDelete] 3,0
SELECT *FROM [DBO].[APPLICATION]
------------------------get details-------------------------------------
create procedure [DBO].[getDetails](@skip int=0,@top int= 40)
as
begin
set nocount on
select appId,appName,appDesp from APPLICATION where isDeleted=0
order by appId
offset @skip rows fetch next @top rows only
end
exec [DBO].[getDetails]
drop procedure [DBO].[getDetails]
