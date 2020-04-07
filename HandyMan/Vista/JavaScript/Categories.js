$(document).ready(function () {
    let state = $("#estados").is(":checked");
    mostrarCategorias(state);
    $("#estados").change(function () {
        if ($(this).prop('checked')) {
            console.log(state);
            mostrarCategorias(state);
        }
        else {
            console.log(state);
            mostrarCategorias(state);
        }     
    });
});

function mostrarCategorias(state) {
    //XMLHttpRequest
    state = $("#estados").is(":checked");
    $.ajax({
        type: 'GET',
        url: 'Categories.aspx/GetCategories?state=' + state,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            loadData(data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}

function loadData(datos) {
    //if (typeof datos !== 'undefined') {
    $("#body_categories").html("");
    $.each(datos, function (k, v) {
        $.each(v, function (key, value) {
            $("#body_categories").append(
                "<tr id='fila_" + value.Id + "'>" +
                    "<td id='miId'>" + value.Id + "</td>" +
                    "<td id='miDes'>" + value.Description + "</td>" +
                    "<td><input type='checkbox' id='" + value.Id + "_state' disabled='disabled' " + (value.State ? "checked='checked'" : "") + "></td>" +
                    "<td>" +
                        "<a href='#editCategoryModal' class='edit' data-id = '" + value.Id + "' data-toggle='modal' >" + "<i class='material-icons' data-toggle='tooltip' title='Edit'>&#xE254;</i>" + "</a>" +
                        "<a href='#deleteCategoryModal' class='delete' data-id = '" + value.Id + "' data-toggle='modal'>" + "<i class='material-icons' data-toggle='tooltip' title='Delete'>&#xE872;</i>" + "</a>" +
                    "</td>" +
                "</tr>"
            ); 
        })
    })
}

/*              AGREGANDO REGISTRO              */
$('#buttonSaveCategory').click(function () {
    var parametros = {
        description: $('#add_inputDescription').val()
    };
    // Ahora hacemos la llamada tipo AJAX utilizando jQuery
    $.ajax({
        type: 'POST',                               // tipo de llamada (POST, GET)
        url: 'Categories.aspx/AddingCategory',      // el URL del método que vamos a llamar        
        data: JSON.stringify(parametros),           // los parámetros en formato JSON
        contentType: "application/json; charset=utf-8",
        dataType: 'json',                           // tipo de datos enviados al servidor
        success: function () {                      // función que se va a ejecutar si el pedido resulta exitoso          
            $("#addCategoryModal").modal('hide');   // una vez dado click en aceptar, el 'hide' hará que se cierre el modal automáticamente
            mostrarCategorias();      
        },
        error: function (req, stat, err) {          // función que se va a ejecutar si el pedido falla
            var error = eval("(" + req.responseText + ")");
            console.log(error);
        }
    });
});

/*              MODIFICANDO REGISTRO             */

$(document).on("click", ".edit", function ()
{
    $('#editCategoryModal').focus();
    var id = $(this).attr("data-id");
    
    $('#edit_inputId').val(id);
    console.log(id);
})

$('#buttonEditCategory').click(function () {
    var parametros = {
        id: $('#edit_inputId').val(),
        description: $('#edit_inputDescription').val()
    };
    // Ahora hacemos la llamada tipo AJAX utilizando jQuery
    $.ajax({
        type: 'POST',
        url: 'Categories.aspx/EditingCategory',
        data: JSON.stringify(parametros),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function () {
            $("#editCategoryModal").modal('hide');
            mostrarCategorias();
        },
        error: function (req, stat, err) {
            var error = eval("(" + req.responseText + ")");
            console.log(error);
        }
    });
});
/*             FIN MODIFICANDO REGISTRO             */

/*              ELIMINANDO REGISTRO             */

$(document).on("click", ".delete", function () {
    $('#deleteCategoryModal').focus();
    var id = $(this).attr("data-id");
    console.log(id);
    $("#buttonDeleteCategory").attr("delete-id", id);
})

$("#buttonDeleteCategory").click(function () {
    var id = $(this).attr("delete-id");
    $.ajax({
        type: 'POST',
        contentType: "application/json;charset=utf-8",
        url: "Categories.aspx/DeletingCategory",
        data: '{eid:' + id + '}',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            if (data) {
                $("#body_categories>#fila_" + id).hide('slow', function () { $(this).remove();  });
            }
            $('#deleteCategoryModal').modal("hide");
        },
        error: function () {
            alert("Error while retrieving data of :" + id);
        }
    });
});
/*           FIN ELIMINANDO REGISTRO             */



