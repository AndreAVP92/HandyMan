//FUNCIÓN PARA LLENAR EL SELECT OPTION CATEGORIES //
//$(document).ready(function () {
//    $.ajax({
//        type: 'POST',
//        url: "SubCategories.aspx/FillCategories",
//        data: "{}",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            loadDropDownList();
//        },
//        error: function (msg) {
//            alert(result.status + ' :' + result.statusText);
//        }
//    });
//});

$(document).ready(function () {
    let state = $("#estados").is(":checked");
    //mostrarDropDownList();
    mostrarSubCategorias(state);
    $("#estados").change(function () {
        if ($(this).prop('checked')) {
            console.log(state);
            mostrarSubCategorias(state);
        }
        else {
            console.log(state);
            mostrarSubCategorias(state);
        }
    });
});

/*          LISTAR SUBCATEGORIAS            */

function mostrarSubCategorias(state) {
    //XMLHttpRequest
    state = $("#estados").is(":checked");
    $.ajax({
        type: 'GET',
        url: 'SubCategories.aspx/GetSubCategories?state=' + state,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            loadData2(data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}

function loadData2(datos) {
    //if (typeof datos !== 'undefined') {
    $("#body_subcategories").html("");
    $.each(datos, function (k, v) {
        $.each(v, function (key, value) {
            $("#body_subcategories").append(
                "<tr id='fila_" + value.Id + "'>" +
                "<td>" + value.Id + "</td>" +
                "<td>" + value.Description + "</td>" +
                "<td><input type='checkbox' id='" + value.Id + "_state' disabled='disabled' " + (value.State ? "checked='checked'" : "") + "></td>" +
                "<td>" +
                "<a href='#editSubCategoryModal' class='edit' data-id = '" + value.Id + "' data-toggle='modal' >" + "<i class='material-icons' data-toggle='tooltip' title='Edit'>&#xE254;</i>" + "</a>" +
                "<a href='#deleteSubCategoryModal' class='delete' data-id = '" + value.Id + "' data-toggle='modal'>" + "<i class='material-icons' data-toggle='tooltip' title='Delete'>&#xE872;</i>" + "</a>" +
                "</td>" +
                "</tr>"
            );
        })
    })
}

//FUNCIÓN PARA LLENAR EL SELECT OPTION CATEGORIES //
//$(function () {
//    $.ajax({
//        type: 'POST',
//        url: "SubCategories.aspx/FillCategories",
//        data: '{}',
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (r) {
//            var ddlCategories = $("[id*=add_selectCategory]");
//            ddlCategories.empty().append('<option selected="selected" value="0">Seleccionar Categoría</option>');
//            $.each(r.d, function () {
//                ddlCategories.append($("<option></option>").val(this['Value']).html(this['Text']));
//            });
//        }
//    })
//})


/*          AGREGAR SUBCATEGORIAS            */

$('#buttonSaveSubCategory').click(function () {
    var parametros = {
        description: $('#add_inputDescription').val(),
        category: document.getElementById('add_selectCategory').value
    };
    // Ahora hacemos la llamada tipo AJAX utilizando jQuery
    $.ajax({
        type: 'POST',                               
        url: 'SubCategories.aspx/AddingSubCategory',              
        data: JSON.stringify(parametros),           
        contentType: "application/json; charset=utf-8",
        dataType: 'json',                           
        success: function () {                                
            $("#addSubCategoryModal").modal('hide');  
            mostrarSubCategorias();
        },
        error: function (req, stat, err) {          
            var error = eval("(" + req.responseText + ")");
            console.log(error);
        }
    });
});


/*              MODIFICANDO REGISTRO             */

$(document).on("click", ".edit", function () {
    $('#editSubCategoryModal').focus();
    var id = $(this).attr("data-id");
    $('#edit_inputId').val(id);
    console.log(id);
})

$('#buttonEditSubCategory').click(function () {
    var parametros = {
        id: $('#edit_inputId').val(),
        description: $('#edit_inputDescription').val()
    };
    // Ahora hacemos la llamada tipo AJAX utilizando jQuery
    $.ajax({
        type: 'POST',
        url: 'SubCategories.aspx/EditingSubCategory',
        data: JSON.stringify(parametros),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function () {
            $("#editSubCategoryModal").modal('hide');
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
    $('#deleteSubCategoryModal').focus();
    var id = $(this).attr("data-id");
    console.log(id);
    $("#buttonDeleteSubCategory").attr("delete-id", id);
})

$("#buttonDeleteSubCategory").click(function () {
    var id = $(this).attr("delete-id");
    $.ajax({
        type: 'POST',
        contentType: "application/json;charset=utf-8",
        url: "SubCategories.aspx/DeletingSubCategory",
        data: '{eid:' + id + '}',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            if (data) {
                $("#body_subcategories>#fila_" + id).hide('slow', function () { $(this).remove(); });
            }
            $('#deleteSubCategoryModal').modal("hide");
        },
        error: function () {
            alert("Error while retrieving data of :" + id);
        }
    });
});
/*           FIN ELIMINANDO REGISTRO             */