$(document).ready(function() {
		

    $(".fancybox-effects-d").click(function() {
        $(".fancybox-effects-d").fancybox();
        $(".fancybox-effects-d").fancybox({

            padding: 15,
         
            openEffect: 'elastic',
            openSpeed: 150,

            closeEffect: 'elastic',
            closeSpeed: 150,

            closeClick: true,

            helpers: {
                overlay: null
            }
        });

    });
			
		
		
		




		});