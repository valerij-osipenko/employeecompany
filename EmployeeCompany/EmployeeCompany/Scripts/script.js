$(document).ready(function () {
        $('.pagination li a').each(function () {
            var hover = $(this).attr('href');
            var addattr = hover + '&statustype=' + $('#statusId').val();
            
            $(this).attr('href', addattr);
        });
        
});