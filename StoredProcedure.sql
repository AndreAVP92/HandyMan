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
			INSERT INTO CATEGORIES(Description, Status) VALUES (@description, 1);
			COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			PRINT ERROR_MESSAGE()
			ROLLBACK TRANSACTION;
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
CREATE PROCEDURE spDeleteCategory(
	@id INT
)
AS
BEGIN
	BEGIN TRY
		--ELIMINO LOGICAMENTE LA CATEGORIA
		UPDATE CATEGORIES SET ESTADO=0 WHERE ID=@id
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
    -- Parámetros de inserción a la tabla SUBCATEGORIES
	@description NVARCHAR(30),
	@status		 BIT,
	-- Parámetros de inserción a la tabla SUBCATEGORIES_x_CATEGORIES
	@idSubCategory INT OUTPUT,
	@idCategory INT
AS
BEGIN
    SET NOCOUNT ON;
	BEGIN TRY
		INSERT INTO SUBCATEGORIES(Description, Status) VALUES (@description, @status);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
		ROLLBACK TRANSACTION;
	END CATCH
	BEGIN TRY
		SELECT @idSubCategory = @@IDENTITY -- recupero el último valor de idSubcategory para insertarlo en la tabla siguiente
		INSERT INTO SUBCATEGORIES_x_CATEGORIES(IdSubCategory_SCC, IdCategory_SCC) VALUES (@idSubCategory, @idCategory);
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
		ROLLBACK TRANSACTION;
	END CATCH
END;
GO