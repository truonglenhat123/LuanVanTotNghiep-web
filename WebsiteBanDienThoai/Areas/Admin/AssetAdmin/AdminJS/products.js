//1. Vô hiệu hóa sản phẩm
//2. Khôi phục sản phẩm
//3. Xóa sản phẩm
//4. Preview Ảnh
//------------------------------------------------/
const deleteOrDisablemodal = $('#delete-disable');
const activateModal = $('#activate');
let id;
var deleteOrDisableConfirm = function (productId,ProductName, productPrice, ProductOldPrice, productImg) {
    deleteOrDisablemodal.find('#product__id').text(ProductName);
    deleteOrDisablemodal.find('#product__old-price').text(ProductOldPrice);
    deleteOrDisablemodal.find('#product__price').text(productPrice);
    deleteOrDisablemodal.find('#product__img').attr('src', productImg);
    deleteOrDisablemodal.modal('show');
    id = productId;
}
$('.dimis-modal').click(function () {
     deleteOrDisablemodal.modal('hide');
     activateModal.modal('hide');
});
//3. Xóa sản phẩm
$('#delete-product').click(function (event) {
    deleteOrDisablemodal.modal('hide');
    $.ajax({
        type: "POST",
        url: '/ProductsAdmin/Delete',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ id: id }),
        dataType: "json",
        success: function (result) {
            if (result == "delete") {
                const Toast = Swal.mixin({
                    toast: true,
                    position: 'top-end',
                    showConfirmButton: false,
                    timer: 1500,
                    didOpen: (toast) => {
                        toast.addEventListener('mouseenter', Swal.stopTimer)
                        toast.addEventListener('mouseleave', Swal.resumeTimer)
                    }
                })
                Toast.fire({
                    icon: 'success',
                    title: 'Xóa thành công'
                })
                $("#item_"+id).remove();
                return;
            }
        },
        error: function () {
            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 1500,
                didOpen: (toast) => {
                    toast.addEventListener('mouseenter', Swal.stopTimer)
                    toast.addEventListener('mouseleave', Swal.resumeTimer)
                }
            })
            Toast.fire({
                icon: 'error',
                title: 'Xóa không thành công'
            })
        }
    });
});

