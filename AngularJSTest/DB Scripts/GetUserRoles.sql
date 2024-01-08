

CREATE PROCEDURE [dbo].[GetUserRoles]

    @Email VARCHAR(50),

    @Name VARCHAR(100),

	@PhoneNumber NVARCHAR(1000)


AS

BEGIN

   SET NOCOUNT ON;

 IF ( @Email = '') AND ( @PhoneNumber = '')    AND (@Name = '')

    BEGIN

	   Select  PG.UsertableID,PG.FirstName,PG.LastName,PG.Email,PG.PhoneNumber  from UserTable  PG where IsDelete = 0
       
    END

    ELSE

    BEGIN

    --Select * from ABOConfirm
        -- Filter by @UserName and @MobileNo if provided

            SELECT PG.UsertableID,PG.FirstName,PG.LastName,PG.Email,PG.PhoneNumber  FROM UserTable	 PG
			


        WHERE	  IsDelete = 0  and

            (@Email IS NULL OR @Email = '' OR PG.Email LIKE '%' + @Email + '%')

            AND

            (@Name IS NULL OR @Name = '' OR PG.FirstName LIKE '%' + @Name + '%')

             AND


            (@PhoneNumber IS NULL OR @Name = '' OR PG.PhoneNumber LIKE '%' + @PhoneNumber + '%')

			

        ORDER BY PG.FirstName DESC;

    END

    SET NOCOUNT OFF;



END;

GO


