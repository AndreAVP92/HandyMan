$(document).ready(function () {
    let state = $("#estados").is(":checked");
    mostrarPagos(state);
    $("#estados").change(function () {
        if ($(this).prop('checked')) {
            console.log(state);
            mostrarPagos(state);
        }
        else {
            console.log(state);
            mostrarPagos(state);
        }
    });
});

function mostrarPagos(state) {
    //XMLHttpRequest
    state = $("#estados").is(":checked");
    $.ajax({
        type: 'GET',
        url: 'Payments.aspx/GetPayments?state=' + state,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            loadDataPayment(data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}

function loadDataPayment(datos) {
    //if (typeof datos !== 'undefined') {
    $("#body_payments").html("");
    $.each(datos, function (k, v) {
        $.each(v, function (key, value) {
            $("#body_payments").append(
                "<tr id='fila_" + value.Id + "'>" +
                "<td>" + value.Id + "</td>" +
                "<td id='t_description'>" + value.Description + "</td>" +
                "<td><input type='checkbox' id='" + value.Id + "_state' disabled='disabled' " + (value.State ? "checked='checked'" : "") + "></td>" +
                "<td>" +
                "<a href='#editPaymentModal' class='edit' data-id = '" + value.Id + "' data-description = '" + value.Description + "' data-state = '" + value.State + "' data-toggle='modal' >" + "<i class='material-icons' data-toggle='tooltip' title='Edit'>&#xE254;</i>" + "</a>" +
                "<a href='#deletePaymentModal' class='delete' data-id = '" + value.Id + "' data-toggle='modal'>" + "<i class='material-icons' data-toggle='tooltip' title='Delete'>&#xE872;</i>" + "</a>" +
                "</td>" +
                "</tr>"
            );
        })
    })
}

/*              AGREGANDO REGISTRO              */
$('#buttonSavePayment').click(function () {
    var parametros = {
        description: $('#add_inputDescription').val()
    };
    // Ahora hacemos la llamada tipo AJAX utilizando jQuery
    $.ajax({
        type: 'POST',                               // tipo de llamada (POST, GET)
        url: 'Payments.aspx/AddingPayment',         // el URL del método que vamos a llamar        
        data: JSON.stringify(parametros),           // los parámetros en formato JSON
        contentType: "application/json; charset=utf-8",
        dataType: 'json',                           // tipo de datos enviados al servidor
        success: function () {                      // función que se va a ejecutar si el pedido resulta exitoso          
            $("#addPaymentModal").modal('hide');    // una vez dado click en aceptar, el 'hide' hará que se cierre el modal automáticamente
            mostrarPagos();
        },
        error: function (req, stat, err) {          // función que se va a ejecutar si el pedido falla
            var error = eval("(" + req.responseText + ")");
            console.log(error);
        }
    });
});

/*              MODIFICANDO REGISTRO             */

$(document).on("click", ".edit", function () {
    $('#editPaymentModal').focus();

    var id = $(this).attr("data-id");
    var desc = $(this).attr("data-description");
    var state = $(this).attr("data-state");

    $('#edit_inputId').val(id);
    $('#edit_inputDescription').val(desc);
    $('#edit_inputState').val(state);
})

$('#button_onoff').click(function () {
    var clase = $('#button_onoff').attr('class');
    // boolean activo = true;
    // Practicando OPERADOR TERNARIO. Muy lindo!
    // No olvidar de darle funcionamiento a estos botones! 
    clase.includes('btn btn-success btn-sm') ? 
        (   $('#button_onoff').removeClass('btn btn-success btn-sm').text('Habilitar'),
            $('#button_onoff').addClass('btn btn-danger btn-sm').text('Deshabilitar')   )
        :
        (   $('#button_onoff').removeClass('btn btn-danger btn-sm').text('Deshabilitar'),
            $('#button_onoff').addClass('btn btn-success btn-sm').text('Habilitar')    )
});

$('#buttonEditPayment').click(function () {

    var parametros = {
        id: $('#edit_inputId').val(),
        description: $('#edit_inputDescription').val(),
        state: $("#button_onoff").is(":checked") ? true : false
    };
 
    // Ahora hacemos la llamada tipo AJAX utilizando jQuery
    $.ajax({
        type: 'POST',
        url: 'Payments.aspx/EditingPayment',
        data: JSON.stringify(parametros),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function () {
            $("#editPaymentModal").modal('hide');
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
    $('#deletePaymentModal').focus();
    var id = $(this).attr("data-id");
    console.log(id);
    $("#buttonDeletePayment").attr("delete-id", id);
})

$("#buttonDeletePayment").click(function () {
    var id = $(this).attr("delete-id");
    $.ajax({
        type: 'POST',
        contentType: "application/json;charset=utf-8",
        url: "Payments.aspx/DeletingPayment",
        data: '{eid:' + id + '}',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            if (data) {
                $("#body_payments>#fila_" + id).hide('slow', function () { $(this).remove(); });
            }
            $('#deletePaymentModal').modal("hide");
        },
        error: function () {
            alert("Error while retrieving data of :" + id);
        }
    });
});
/*           FIN ELIMINANDO REGISTRO             */