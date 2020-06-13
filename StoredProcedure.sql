USE HandyMan_DB
GO
---------------------------------------------------------------------------------
---           STORED PROCEDURE INSERTAR CATEGORIA							  ---
---------------------------------------------------------------------------------
CREATE PROCEDURE SP_InsertCategory
@description NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
		BEGIN TRY
			BEGIN TRANSACTION
				IF NOT EXISTS (SELECT * FROM CATEGORIES WHERE Description = @description)
					INSERT INTO CATEGORIES(Description, Status) VALUES (@description, 1);			
			COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			PRINT ERROR_MESSAGE()
			--Transaction uncommittable
			IF(XACT_STATE()) = -1
			ROLLBACK TRANSACTION;
			--Transaction committable
			IF(XACT_STATE()) = 1
			COMMIT TRANSACTION;
		END CATCH
END;
GO
---------------------------------------------------------------------------------
---           STORED PROCEDURE MODIFICAR CATEGORIA							  ---
---------------------------------------------------------------------------------
CREATE PROCEDURE SP_EditCategory
@id INT,
@description NVARCHAR(30),
@status BIT
AS 
BEGIN
	SET NOCOUNT ON;
		BEGIN TRY
			BEGIN TRANSACTION
				UPDATE CATEGORIES SET Description=@description, Status=@status WHERE Id=@id
			COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			PRINT ERROR_MESSAGE()
			ROLLBACK TRANSACTION;
		END CATCH
END;
GO
---------------------------------------------------------------------------------
---           STORED PROCEDURE ELIMINAR CATEGORIA						      ---
---------------------------------------------------------------------------------
CREATE PROCEDURE SP_DeleteCategory(
	@id INT
)
AS
BEGIN
	BEGIN TRY
		--ELIMINO LOGICAMENTE LA CATEGORIA
		UPDATE CATEGORIES SET Status=0 WHERE ID=@id
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
	END CATCH
END
GO
---------------------------------------------------------------------------------
---           STORED PROCEDURE INSERTAR SUBCATEGORIA						  ---
---------------------------------------------------------------------------------
CREATE PROCEDURE SP_InsertSubCategory
    -- Par�metros de inserci�n a la tabla SUBCATEGORIES
	@description NVARCHAR(30),
	-- Par�metros de inserci�n a la tabla SUBCATEGORIES_x_CATEGORIES
	--@idSubCategory INT OUT,
	@idCategory INT
AS
BEGIN
    SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION
		INSERT INTO SUBCATEGORIES(Description, Status) VALUES (@description, 1);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
		ROLLBACK TRANSACTION;
	END CATCH
	BEGIN TRY
		BEGIN TRANSACTION
		DECLARE @idSubCategory INT
		SELECT @idSubCategory = @@IDENTITY -- recupero el �ltimo valor de idSubcategory para insertarlo en la tabla siguiente
		INSERT INTO SUBCATEGORIES_x_CATEGORIES(IdSubCategory_SCC, IdCategory_SCC) VALUES (@idSubCategory, @idCategory);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
		ROLLBACK TRANSACTION;
	END CATCH
END;
GO
---------------------------------------------------------------------------------
---           STORED PROCEDURE ELIMINAR SUB CATEGORIA						  ---
---------------------------------------------------------------------------------
CREATE PROCEDURE SP_DeleteSubCategory(
	@id INT
)
AS
BEGIN
	BEGIN TRY
		--ELIMINO LOGICAMENTE LA CATEGORIA
		UPDATE SUBCATEGORIES SET Status=0 WHERE ID=@id
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
	END CATCH
END
GO
---------------------------------------------------------------------------------
---           STORED PROCEDURE MODIFICAR SUB CATEGORIA						  ---
---------------------------------------------------------------------------------
CREATE PROCEDURE SP_EditSubCategory
@id INT,
@description NVARCHAR(30),
@status BIT
AS 
BEGIN
	SET NOCOUNT ON;
		BEGIN TRY
			BEGIN TRANSACTION
				UPDATE CATEGORIES SET Description=@description, Status=@status WHERE Id=@id
			COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			PRINT ERROR_MESSAGE()
			ROLLBACK TRANSACTION;
		END CATCH
END;
GO
---------------------------------------------------------------------------------
---               STORED PROCEDURE INSERTAR MEDIOS DE PAGO					  ---
---------------------------------------------------------------------------------
CREATE PROCEDURE SP_InsertPayment
@description NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
		BEGIN TRY
			BEGIN TRANSACTION
				IF NOT EXISTS (SELECT * FROM PAYMENTS WHERE Description = @description)
					INSERT INTO PAYMENTS(Description, Status) VALUES (@description, 1);			
			COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			PRINT ERROR_MESSAGE()
			--Transaction uncommittable
			IF(XACT_STATE()) = -1
			ROLLBACK TRANSACTION;
			--Transaction committable
			IF(XACT_STATE()) = 1
			COMMIT TRANSACTION;
		END CATCH
END;
GO
---------------------------------------------------------------------------------
---           STORED PROCEDURE MODIFICAR MEDIO DE PAGO						  ---
---------------------------------------------------------------------------------
CREATE PROCEDURE SP_EditPayment
@id INT,
@description NVARCHAR(30),
@status BIT
AS 
BEGIN
	SET NOCOUNT ON;
		BEGIN TRY
			BEGIN TRANSACTION
				UPDATE PAYMENTS SET Description=@description, Status=@status WHERE Id=@id
			COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			PRINT ERROR_MESSAGE()
			ROLLBACK TRANSACTION;
		END CATCH
END;
GO
---------------------------------------------------------------------------------
---           STORED PROCEDURE ELIMINAR MEDIO DE PAGO						  ---
---------------------------------------------------------------------------------
CREATE PROCEDURE SP_DeletePayment(
	@id INT
)
AS
BEGIN
	BEGIN TRY
		--ELIMINO LOGICAMENTE LA CATEGORIA
		UPDATE PAYMENTS SET Status=0 WHERE ID=@id
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
	END CATCH
END
GO
