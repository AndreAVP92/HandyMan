$(document).ready(function () {   
    mostrarCategorias();
});

function mostrarCategorias() {
    //XMLHttpRequest
    $.ajax({
        type: 'POST',
        url: 'crud_Categories.aspx/GetCategories',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            armarTabla(data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}

function armarTabla(datos) {
    //if (typeof datos !== 'undefined') {
        $("#body_categories").html("");
        $.each(datos, function (k, v) {
            $.each(v, function (key, value) {
                $("#body_categories").append(
                    "<tr>" +
      //                  "<td>" +
      //                      "<span class='custom-checkbox'>" +
      //                          "<input type='checkbox' id='checkbox1' name='options[]' value='1'>" +
      //                              "<label for='checkbox1'>" + "</label>" +
						//	"</span>" + 
						//"</td>" +
                            "<td>" + value.Id + "</td>" +
                            "<td>" + value.Description + "</td>" +
                            "<td>" + value.State + "</td>" +
                            "<td>" +
                                "<a href='#editCategoryModal' class='edit' data-id = 'value.Id' data-toggle='modal' >" + "<i class='material-icons' data-toggle='tooltip' title='Edit'>&#xE254;</i>" + "</a>" +
                                "<a  id='deleteCategory' class='delete' data-id = 'value.Id' data-toggle='modal'>" + "<i class='material-icons' data-toggle='tooltip' title='Delete'>&#xE872;</i>" + "</a>" +
                            "</td>" +
                    "</tr>"
                    /*/*href='#deleteCategoryModal'*/
                ); // NO OLVIDAR PONER 'data-id = value.Id' PARA ASIGNAR EL ID POR CADA BOTON ELIMINAR/EDITAR
            })
        })
    //}
}

function cargarTabla() {
    $.ajax({
        type: 'GET',
        url: "crud_Categories.aspx",
        //async: true,
        success: function () {
            mostrarCategorias();
            $("#body_categories").html("");
            //$("#body_categories").html(respuesta); //no funciona así
        },
         error: function (request, error) {
             console.log(error);
        }
    });
}

$('#buttonSaveCategory').click(function () {
    //e.preventDefault();  //Usamos esta línea para cancelar el postback que el botón crea

    var parametros = {
        description: $('#add_inputDescription').val()
    };
    // Ahora hacemos la llamada tipo AJAX utilizando jQuery
    $.ajax({
        type: 'POST',                               // tipo de llamada (POST, GET)
        url: 'crud_Categories.aspx/AddingCategory', // el URL del método que vamos a llamar        
        data: JSON.stringify(parametros),           // los parámetros en formato JSON
        contentType: "application/json; charset=utf-8",
        dataType: 'json',                           // tipo de datos enviados al servidor
        success: function () {                      // función que se va a ejecutar si el pedido resulta exitoso          
            $("#addCategoryModal").modal('hide');   // una vez dado click en aceptar, el 'hide' hará que se cierre el modal automáticamente
            cargarTabla();
            //armarTabla(data);            
        },
        error: function (req, stat, err) {          // función que se va a ejecutar si el pedido falla
            var error = eval("(" + req.responseText + ")");
            console.log(error);
            //$('#lblMensaje').text(error.Message);
        }
    });
});
$('#deleteCategory').click(function () {
    var id = $(this).attr("data-id");
    $.ajax({
        type: 'POST',
        url: 'crud_Categories.aspx/DeletingCategory', // el URL del método que vamos a llamar        
        data: '{eid:' + id + '}',         // los parámetros en formato JSON
        contentType: "application/json; charset=utf-8",
        dataType: 'json',                           // tipo de datos enviados al servidor
        success: function () {
            if (confirm("Are you sure you want to delete !") == true) {
                alert("Data Deleted successfully");
            } else {
                alert("You have canceled the changes");
            } 
                //$("#deleteCategoryModal").modal('hide');
                cargarTabla();
            },    
        error: function (req, stat, err) {          // función que se va a ejecutar si el pedido falla
            var error = eval("(" + req.responseText + ")");
            console.log(error);
            //$('#lblMensaje').text(error.Message);
        }
    });
});

// PARA ELIMINAR //
//$(document).on("click", ".edit", function () {
//    $('#editCategoryModal').focus();
//    var id = $(this).attr("data-id");
//    console.log(id);
//    $("#buttonEditCategory").attr("edit-id", id);
//    $.ajax({
//        type: 'POST',
//        contentType: "application/json;charset=utf-8",
//        url: "crud_Categories.aspx/EditingCategory",
//        data: '{id:' + id + '}',
//        dataType: "json",
//        success: function (data) {
//            var category = $.parseJSON(data.id);
//            $.each(category, function (index, value) {
//                $('#idCategory').val(value.Id);
//                $('#edit_inputDescription').val(value.Description)
//            });
//        },
//        error: function () {
//            alert("Error while retrieving data of :" + id);
//        }
//    });
//});


//$('#buttonEditCategory').click(function () {
//    //e.preventDefault();  //Usamos esta línea para cancelar el postback que el botón crea
   
//    var parametros = {
//        id: $('#idCategory').attr("data-id"),       
//        description: $('#edit_inputDescription').val()
//    };
//    console.log(id);
//    // Ahora hacemos la llamada tipo AJAX utilizando jQuery
//    $.ajax({
//        type: 'POST',                               // tipo de llamada (POST, GET)
//        url: 'crud_Categories.aspx/EditingCategory', // el URL del método que vamos a llamar        
//        data: JSON.stringify(parametros),           // los parámetros en formato JSON
//        contentType: "application/json; charset=utf-8",
//        dataType: 'json',                           // tipo de datos enviados al servidor
//        success: function () {                      // función que se va a ejecutar si el pedido resulta exitoso          
//            $("#editCategoryModal").modal('hide');   // una vez dado click en aceptar, el 'hide' hará que se cierre el modal automáticamente
//            cargarTabla();
//            //armarTabla(data);            
//        },
//        error: function (req, stat, err) {          // función que se va a ejecutar si el pedido falla
//            var error = eval("(" + req.responseText + ")");
//            console.log(error);
//            //$('#lblMensaje').text(error.Message);
//        }
//    });
//});