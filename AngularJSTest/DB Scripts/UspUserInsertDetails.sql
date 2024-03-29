
create PROCEDURE [dbo].[UspUserInsertDetails]
    @Action VARCHAR(10),
   @UserTableID INT,  
    @FirstName VARCHAR(255),
    @LastName VARCHAR(255),
    @Email VARCHAR(255),
    @PhoneNumber VARCHAR(20),
    @Address VARCHAR(255),
    @City VARCHAR(100),
    @State VARCHAR(100),
    @Country VARCHAR(100),
    @PostalCode VARCHAR(20)
    ,@IsSucced				BIGINT OUTPUT
AS

SET NOCOUNT ON;

BEGIN

BEGIN TRY

		BEGIN TRANSACTION
		IF @Action = 'Insert' 
		  BEGIN
			INSERT INTO  UserTable (FirstName,LastName,Email,PhoneNumber,Address,City,State,Country,PostalCode,IsDelete,Createddate)values

		   (@FirstName,@LastName,@Email,@PhoneNumber,@Address,@City,@State,@Country,@PostalCode,0,Getdate())

		  
			 SET @IsSucced = 1
		  END

		  ELSE IF  @Action = 'Update'
		  BEGIN
			Update UserTable  SET FirstName =@FirstName, LastName=@LastName, Email=@Email,PhoneNumber=@PhoneNumber,Address=@Address ,City=@City,
			 State=@State, Country=@Country,PostalCode=@PostalCode 
			 ,IsDelete =0 ,  Createddate = GETDATE() Where 	UserTableID= @UserTableID
             SET @IsSucced = 2
		  END 
   
          ELSE IF  @Action = 'Delete'
		  BEGIN
			Update UserTable  SET IsDelete =1 ,  Createddate = GETDATE()   Where 	UserTableID= @UserTableID
					    SET @IsSucced = 3
		  END 
		  else
		   BEGIN
		     SET @IsSucced = -1
			     END 
		  COMMIT TRANSACTION

	END TRY

	BEGIN CATCH

		
		ROLLBACK TRANSACTION

		


	END CATCH

END


SET NOCOUNT OFF;
  



	
        
