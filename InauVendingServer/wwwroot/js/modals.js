$(".MachineDelete").click('[data-id]', function (e) {
    e.preventDefault();
    var id = $(this).data('id');

    $.ajax({
        method: 'GET',
        url: '/Machines/Delete/' + id
    })
        .done(function (data) {
            $("#MachineDeleteModal").html(data);
            $("#MachineDeleteModal").find('#MachineDeleteModals').modal('show');


        })
        .error(function () {

            alert('Erro');
        });
});

$(document).on('click', '.ProductMachineAdd', '[data-id]', function (e) {
    e.preventDefault();
    var id = $(this).data('id');

    $.ajax({
        method: 'GET',
        url: '/ProductMachines/Create/' + id
    })
        .done(function (data) {
            $("#ProductMachineAddModal").html(data);
            $("#ProductMachineAddModal").find('#ProductMachineAddModals').modal('show');


        })
        .error(function () {

            alert('Erro');
        });
});

$(document).on('click', '.SupplyAdd', '[data-id]', function (e) {
    e.preventDefault();
    var id = $(this).data('id');

    $.ajax({
        method: 'GET',
        url: '/Supplies/Create/' + id
    })
        .done(function (data) {
            $("#SupplyAddModal").html(data);
            $("#SupplyAddModal").find('#SupplyAddModals').modal('show');


        })
        .error(function () {

            alert('Erro');
        });
});

$(document).on('click', '#SupplyAdd2', function (e) {
    e.preventDefault();

    $.ajax({
        method: 'GET',
        url: '/Supplies/Create/'
    })
        .done(function (data) {
            $("#SupplyAddModal").html(data);
            $("#SupplyAddModal").find('#SupplyAddModals').modal('show');


        })
        .error(function () {

            alert('Erro');
        });
});

$(document).on('click', '.SupplyDelete', '[data-id]', function (e) {
    e.preventDefault();
    var id = $(this).data('id');
    $.ajax({
        method: 'GET',
        url: '/Supplies/Delete/' + id
    })
        .done(function (data) {
            $("#SupplyDeleteModal").html(data);
            $("#SupplyDeleteModal").find('#SupplyDeleteModals').modal('show');


        })
        .error(function () {

            alert('Erro');
        });
});

$(document).on('click', '.ProductMachineDelete', '[data-id]', function (e) {
    e.preventDefault();
    var id = $(this).data('id');
    $.ajax({
        method: 'GET',
        url: '/ProductMachines/Delete/' + id
    })
        .done(function (data) {
            $("#ProductMachineDeleteModal").html(data);
            $("#ProductMachineDeleteModal").find('#ProductMachineDeleteModals').modal('show');


        })
        .error(function () {

            alert('Erro');
        });
});

$(document).on('click', '#MaintenanceAdd', '[data-id]', function (e) {
    e.preventDefault();
    var id = $(this).data('id');

    $.ajax({
        method: 'GET',
        url: '/MachineMaintenances/Create/' + id
    })
        .done(function (data) {
            $("#MaintenanceAddModal").html(data);
            $("#MaintenanceAddModal").find('#MaintenanceAddModals').modal('show');


        })
        .error(function () {

            alert('Erro');
        });
});

$(document).on('click', '.MaintenanceDelete', '[data-id]', function (e) {
    e.preventDefault();
    var id = $(this).data('id');
    $.ajax({
        method: 'GET',
        url: '/MachineMaintenances/Delete/' + id
    })
        .done(function (data) {
            $("#MaintenanceDeleteModal").html(data);
            $("#MaintenanceDeleteModal").find('#MaintenanceDeleteModals').modal('show');


        })
        .error(function () {

            alert('Erro');
        });
});

$(document).on('click', '.MachineEdit', '[data-id]', function (e) {
    e.preventDefault();
    var id = $(this).data('id');
    $.ajax({
        method: 'GET',
        url: '/Machines/Edit/' + id
    })
        .done(function (data) {
            $("#MachineEditModal").html(data);
            $("#MachineEditModal").find('#MachineEditModals').modal('show');


        })
        .error(function () {

            alert('Erro');
        });
});

$(document).on('click', '#MachineAdd', function (e) {
    e.preventDefault();

    $.ajax({
        method: 'GET',
        url: '/Machines/Create/'
    })
        .done(function (data) {
            $("#MachineAddModal").html(data);
            $("#MachineAddModal").find('#MachineAddModals').modal('show');


        })
        .error(function () {

            alert('Erro');
        });
});

$(document).on('click', '#ProductAdd', function (e) {
    e.preventDefault();

    $.ajax({
        method: 'GET',
        url: '/Products/Create/'
    })
        .done(function (data) {
            $("#ProductAddModal").html(data);
            $("#ProductAddModal").find('#ProductAddModals').modal('show');
        })
        .error(function () {
            alert('Erro');
        });
});

$(document).on('click', '.ProductEdit', '[data-id]', function (e) {
    e.preventDefault();
    var id = $(this).data('id');
    $.ajax({
        method: 'GET',
        url: '/Products/Edit/' + id
    })
        .done(function (data) {
            $("#ProductEditModal").html(data);
            $("#ProductEditModal").find('#ProductEditModals').modal('show');
        })
        .error(function () {

            alert('Erro');
        });
});

$(document).on('click', '.ProductDelete', '[data-id]', function (e) {
    e.preventDefault();
    var id = $(this).data('id');
    $.ajax({
        method: 'GET',
        url: '/Products/Delete/' + id
    })
        .done(function (data) {
            $("#ProductDeleteModal").html(data);
            $("#ProductDeleteModal").find('#ProductDeleteModals').modal('show');


        })
        .error(function () {

            alert('Erro');
        });
});

