// scripts.js

function mostrarModal(btn) {
    var mesaSeleccionada = btn.textContent.trim(); // Obtener número de mesa eliminando espacios en blanco
    var mesaAbierta = btn.classList.contains('btn-danger'); // Verificar clase para determinar estado de la mesa

    if (mesaAbierta) {
        // Redireccionar a Pedi2.aspx con el número de mesa en la URL
        window.location.href = 'Pedi2.aspx?mesa=' + mesaSeleccionada;
    } else {
        $('#modalConfirmar').find('.modal-body').text('¿Desea abrir la mesa ' + mesaSeleccionada + '?');
        $('#modalConfirmar').data('accion', 'abrir');
        $('#modalConfirmar').data('btn', btn).modal('show');
    }
}

function confirmarMesa() {
    var btn = $('#modalConfirmar').data('btn');
    var accion = $('#modalConfirmar').data('accion');
    var mesaSeleccionada = btn.textContent.trim(); // Obtener número de mesa eliminando espacios en blanco

    if (accion === 'abrir') {
        // Aquí puedes agregar lógica adicional si es necesaria antes de confirmar la acción
        $.ajax({
            type: "POST",
            url: "Salon.aspx/ConfirmarAbrirCerrarMesa",
            data: JSON.stringify({ idMesa: mesaSeleccionada }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                btn.classList.add('btn-danger'); // Cambiar clase del botón a cerrar
                btn.textContent = 'Cerrar'; // Cambiar texto del botón a cerrar
                $('#modalConfirmar').modal('hide');
                $('#numeroMesa').text(mesaSeleccionada); // Mostrar número de mesa seleccionada
                $('#seccionPedidos').show(); // Mostrar sección de pedidos
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
    } else if (accion === 'cerrar') {
        // Aquí puedes agregar la lógica para cerrar la mesa si es necesario
    }
}
