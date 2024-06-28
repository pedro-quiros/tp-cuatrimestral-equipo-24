function mostrarModal(btn) {
    var numeroMesa = btn.getAttribute('data-numeromesa');
    var idMesa = btn.getAttribute('data-idmesa');
    var mesaAbierta = btn.classList.contains('btn-danger');

    if (mesaAbierta) {
        window.location.href = 'Pedi2.aspx?mesa=' + numeroMesa;
    } else {
        $('#modalMensaje').text('¿Desea abrir la mesa ' + numeroMesa + '?');
        $('#modalConfirmar').data('accion', 'abrir');
        $('#modalConfirmar').data('btn', btn);
        $('#modalConfirmar').data('idMesa', idMesa);
        $('#modalConfirmar').modal('show');
    }
}

function confirmarMesa() {
    var btn = $('#modalConfirmar').data('btn');
    var accion = $('#modalConfirmar').data('accion');
    var idMesa = $('#modalConfirmar').data('idMesa');

    if (accion === 'abrir') {
        $.ajax({
            type: "POST",
            url: "Salon.aspx/ConfirmarAbrirCerrarMesa",
            data: JSON.stringify({ idMesa: idMesa, estado: 'Abrir' }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                btn.classList.remove('btn-primary');
                btn.classList.add('btn-danger');
                btn.textContent = 'Cargar Pedido';
                $('#modalConfirmar').modal('hide');
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
    }
}

function cerrarModalConfirmacion() {
    $('#modalConfirmar').modal('hide');
}

$(document).ready(function () {
    $('#btnAceptar').on('click', function () {
        confirmarMesa();
    });

    $('#btnCancelar').on('click', function () {
        cerrarModalConfirmacion();
    });
});
