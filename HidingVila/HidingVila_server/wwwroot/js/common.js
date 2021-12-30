window.showMessage = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'Operation Succeed!')
    }
    if (type === "error") {
        toastr.error(message, 'Operation Faild!')
    }
}

function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}