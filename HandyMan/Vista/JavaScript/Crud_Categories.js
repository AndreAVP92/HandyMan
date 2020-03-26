//function listarCategorias() {
//    $.ajax({
//        type: "POST",
//        contentType: "application/json; charset=utf-8",
//        url: 'crud_Categories.aspx/GetCategories', //GetCategories es el WebMethod  
//        data: {},
//        dataType: "json",
//        success: function (data) {
//            $('#body_categories tbody').remove(); // Every time I am removing the body of Table and applying loop to display data  
//            //console.log(data.d);    
//            for (var i = 0; i < data.d.length; i++) {
//                $("#body_categories").append(
//                    //"<tr>" +
//                    //"<th > " + data.d[i].nombre + "</th > <th>" + data.d[i].fecha + "</th>" +
//                    //"<th>" + data.d[i].idpais + "</td>" + "<th>" + data.d[i].credito + "</td>" +
//                    //"<th>" + "<input type='button' class='btn btn-primary editButton' data-id='" + data.d[i].Id + "' data-toggle='modal' data-target='#myModal' name='submitButton' id='botonEditar' value='Editar' />" + "</th>" +
//                    //"<th><input type='button' class='btn btn-primary' name='submitButton' id='btnDelete' value='Delete'/> </th>" +
//                    //"</tr > ");
//                "<tr>" +
//                    //                  "<td>" +
//                    //                      "<span class='custom-checkbox'>" +
//                    //                          "<input type='checkbox' id='checkbox1' name='options[]' value='1'>" +
//                    //                              "<label for='checkbox1'>" + "</label>" +
//                    //	"</span>" + 
//                    //"</td>" +
//                    "<td>" + data.d[i].Description + "</td>" +
//                    "<td>" + data.d[i].State + "</td>" +
//                    //"<td style='text-align:right'>" +
//                    //    "<a href='#editCategoryModal' class='edit' data-toggle='modal' >" + "<i class='material-icons' data-toggle='tooltip' title='Edit'>&#xE254;</i>" + "</a>" +
//                    //    "<a href='#deleteCategoryModal' class='delete' data-toggle='modal'>" + "<i class='material-icons' data-toggle='tooltip' title='Delete'>&#xE872;</i>" + "</a>" +
//                    //"</td>" +
//                    "</tr>");
//            }
//        },
//        error: function () {
//            alert("Error al mostrar datos");
//        }
//    });
//}

$(document).ready(function () {
    buscarCategorias();
});

function buscarCategorias() {
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
    if (typeof datos !== 'undefined') {
        $("#body_categories").html("");
        $.each(datos, function (k, v) {
            $.each(v, function (key, value) {
                $("#body_categories").append(
                    "<tr>" +
                        "<td>" +
                            "<span class='custom-checkbox'>" +
                                "<input type='checkbox' id='checkbox1' name='options[]' value='1'>" +
                                    "<label for='checkbox1'>" + "</label>" +
							"</span>" + 
						"</td>" +
                            //"<td>" + value.Id + "</td" > +
                            "<td>" + value.Description + "</td>" +
                            "<td>" + value.State + "</td>" +
                            "<td style='text-align:right'>" +
                                "<a href='#editCategoryModal' class='edit' data-toggle='modal' >" + "<i class='material-icons' data-toggle='tooltip' title='Edit'>&#xE254;</i>" + "</a>" +
                                "<a href='#deleteCategoryModal' class='delete' data-toggle='modal'>" + "<i class='material-icons' data-toggle='tooltip' title='Delete'>&#xE872;</i>" + "</a>" +
                            "</td>" +
                    "</tr>"
                ); // NO OLVIDAR PONER data-id PARA ASIGNAR EL ID POR CADA BOTON ELIMINAR/EDITAR
            })
        })
    }
}

//$(document).ready(function () {
//    $("#buttonSaveCategory").click(function () {
//        $.ajax({
//            type: "POST",
//            url: "crud_Categories.aspx/GetUsuarios",
//            cache: true,
//            async: false,
//            data: "{}",
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            success: function (resultado) {
//                var items = resultado.d;
//                $.each(items, function (index, item) {
//                    $("#body_categories").append(
//                        "<tr>" +
//                        "<td>" +
//                        "<span class='custom-checkbox'>" +
//                        "<input type='checkbox' id='checkbox1' name='options[]' value='1'>" +
//                        "<label for='checkbox1'>" + "</label>" +
//                        "</span>" +
//                        "</td>" +
//                        "<td>" + item.Id + "</td" > +
//                        "<td>" + item.Description + "</td>" +
//                        "<td>" + item.State + "</td>" +
//                        "<td style='text-align:right'>" +
//                        "<a href='#editCategoryModal' class='edit' data-toggle='modal' >" + "<i class='material-icons' data-toggle='tooltip' title='Edit'>&#xE254;</i>" + "</a>" +
//                        "<a href='#deleteCategoryModal' class='delete' data-toggle='modal'>" + "<i class='material-icons' data-toggle='tooltip' title='Delete'>&#xE872;</i>" + "</a>" +
//                        "</td>" +
//                        "</tr>"
//                    );
//                });
//            },
//            error: function (result) {
//                alert("Ups, ¿qué habrá pasado?");
//            }
//        });
//    });
//});

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
            $("#addCategoryModal").modal('hide');
            armarTabla(data); 
        },
        error: function (req, stat, err) {          // función que se va a ejecutar si el pedido falla
            var error = eval("(" + req.responseText + ")");
            console.log(error);
            //$('#lblMensaje').text(error.Message);
        }
    });
});