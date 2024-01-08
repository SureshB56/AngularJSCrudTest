

CREATE PROCEDURE [dbo].[GetUserId]

    @UserTableID Int



AS

BEGIN

   SET NOCOUNT ON;

    Select * from  	UserTable where UserTableID = 	@UserTableID

    SET NOCOUNT OFF;



END;

GO


