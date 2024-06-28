// scripts.js

function mostrarModal(btn) {
    var mesaSeleccionada = btn.textContent; // Obtener número de mesa
    var mesaAbierta = btn.classList.contains('clicked');

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
    var mesaSeleccionada = btn.textContent; // Obtener número de mesa

    if (accion === 'abrir') {
        btn.classList.add('clicked');
        $('#modalConfirmar').modal('hide');
        $('#numeroMesa').text(mesaSeleccionada); // Mostrar número de mesa seleccionada
        $('#seccionPedidos').show(); // Mostrar sección de pedidos
    } else if (accion === 'cerrar') {
        btn.classList.remove('clicked');
        $('#modalConfirmar').modal('hide');
        // Aquí puedes agregar la lógica para cerrar la mesa si es necesario
    }
}