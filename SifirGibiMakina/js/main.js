$("#banner-slider").owlCarousel({
  items: 1,
  loop: false,
  center: true,
  margin: 10,
  dots: false,
  URLhashListener: true,
  autoplayHoverPause: true,
  startPosition: "URLHash",
});

$("#kategori-slider").owlCarousel({
  loop: false,
  autoplay: false,
  margin: 20,
  center: true,
  startPosition: 1,
  nav: true,
  dots: false,
  responsive: {
    0: {
      items: 1,
      nav: false,
      dots: true,
      center: true,
      startPosition: 1,
    },
    768: {
      items: 4,
    },
  },
});

$("#sgm-magazalar-slider").owlCarousel({
    loop: true,
  autoplay: true,
  margin: 20,
    nav: false,
    autoplayTimeout: 1000,
    dots: true,
    autoplayHoverPause: true,
  responsive: {
    0: {
      items: 2,
      nav: false,
      dots: true,
    },
    768: {
      items: 6,
    },
  },
});

$("#neden-sifir-gibi-makine").owlCarousel({
  loop: false,
  items: 2,
  autoplay: false,
  margin: 20,
  nav: false,
  dots: true,
});

$("#yeni-eklenenler-slider").owlCarousel({
  loop: false,
  center: true,
  startPosition: 1,
  autoplay: false,
  margin: 20,
  nav: true,
  dots: false,
  responsive: {
    0: {
      items: 2,
      nav: false,
      dots: true,
    },
    768: {
      items: 4,
    },
  },
});

$("#ihalelerimiz-slider").owlCarousel({
  loop: true,
  autoplay: false,
  margin: 16,
  nav: true,
  dots: false,
  responsive: {
    0: {
      items: 1,
      nav: false,
      dots: true,
    },
    768: {
      items: 3,
    },
  },
});

$("#blog-slider").owlCarousel({
  loop: true,
  autoplay: false,
  margin: 20,
  nav: true,
  dots: false,
  responsive: {
    0: {
      items: 2,
      nav: false,
      dots: true,
    },
    768: {
      items: 3,
    },
  },
});

$("#kategoriye-gore-slider").owlCarousel({
  loop: true,
  autoplay: false,
  margin: 20,
  nav: true,
  dots: false,
  responsive: {
    0: {
      items: 1,
      nav: false,
      dots: true,
    },
    768: {
      items: 3,
    },
  },
});

$("#makine-al-slider").owlCarousel({
  loop: true,
  autoplay: false,
  margin: 20,
  nav: true,
  dots: false,
  responsive: {
    0: {
      items: 3,
      nav: false,
      dots: true,
    },
    768: {
      items: 2,
    },
  },
});

$("#urun-detay-slider").owlCarousel({
  items: 1,
  dots: false,
  nav: true,
  loop: false,
  center: true,
  margin: 10,
  URLhashListener: true,
  autoplayHoverPause: true,
  startPosition: "URLHash",
});

$("#benzer-urunler-slider").owlCarousel({
  loop: true,
  autoplay: false,
  margin: 20,
  nav: true,
  dots: false,
  responsive: {
    0: {
      items: 2,
    },
    768: {
      items: 2,
    },
    992: {
      items: 4,
    }
  },
});

/* COUNTER */

// Create Countdown
var Countdown = {

  // Backbone-like structure
  $el: $('.countdown'),

  // Params
  countdown_interval: null,
  total_seconds: 0,

  // Initialize the countdown  
  init: function() {
    var Today           = new Date();
    var Todayday        = Today.getDate(); // getDay() is an integer corresponding to the day of the week: 0 for Sunday, 1 for Monday, 2 for Tuesday, and so on.
    var Todayhours      = Today.getHours();
    var Todayminutes    = Today.getMinutes();
    var Todayseconds    = Today.getSeconds();

    var DeadLine        = new Date('January 22, 2022 23:59');
    var DeadLineday     = DeadLine.getDate();
    var DeadLinehours   = DeadLine.getUTCHours(); // I'm not sure why getHours() here is "loaded jangá"
    var DeadLineminutes = DeadLine.getMinutes();
    var DeadLineseconds = DeadLine.getSeconds();

    // DOM
    this.$ = {
      days:     this.$el.find('.bloc-time.days .figure'),
      hours:    this.$el.find('.bloc-time.hours .figure'),
      minutes:  this.$el.find('.bloc-time.min .figure'),
      seconds:  this.$el.find('.bloc-time.sec .figure')
    };

    // Init countdown values
    this.values = {
      days:     DeadLineday - Todayday,
      hours:    DeadLinehours - Todayhours,
      minutes:  DeadLineminutes - Todayminutes,
      seconds:  DeadLineseconds - Todayseconds
    };

    // Initialize total seconds
    // this.total_seconds = ((this.values.days * 24) + (this.values.hours * 60 * 60 + (this.values.minutes * 60))) + this.values.seconds;
    this.total_seconds = this.values.seconds + (this.values.minutes * 60) + (this.values.hours * 60 * 60) + (this.values.days * 24 * 60 * 60);

    // Animate countdown to the end 
    this.count();
  },

  count: function() {

    var that = this,
      $day_1  = this.$.days.eq(0),
      $day_2  = this.$.days.eq(1),
      $hour_1 = this.$.hours.eq(0),
      $hour_2 = this.$.hours.eq(1),
      $min_1  = this.$.minutes.eq(0),
      $min_2  = this.$.minutes.eq(1),
      $sec_1  = this.$.seconds.eq(0),
      $sec_2  = this.$.seconds.eq(1);

    this.countdown_interval = setInterval(function() {

      if (that.total_seconds > 0) {

        --that.values.seconds;

        if (that.values.minutes >= 0 && that.values.seconds <= 0) {

          that.values.seconds = 59;
          --that.values.minutes;
        } // end if

        if (that.values.hours >= 0 && that.values.minutes <= 0) {

          that.values.minutes = 59;
          --that.values.hours;
        } // end if

        if (that.values.days >= 0 && that.values.hours <= 0) {

          that.values.hours = 24;
          --that.values.days;
        } // end if

        // Update DOM values
        // Days
        that.checkDay(that.values.days, $day_1, $day_2);

        // Hours
        that.checkDay(that.values.hours, $hour_1, $hour_2);

        // Minutes
        that.checkDay(that.values.minutes, $min_1, $min_2);

        // Seconds
        that.checkDay(that.values.seconds, $sec_1, $sec_2);

        --that.total_seconds;
      } // end if(that.total_seconds > 0)
      else {
        clearInterval(that.countdown_interval);
      }
    }, 1000);
  },

  animateFigure: function($el, value) {

    var that = this,
      $top = $el.find('.top'),
      $bottom = $el.find('.bottom'),
      $back_top = $el.find('.top-back'),
      $back_bottom = $el.find('.bottom-back');

    // Before we begin, change the back value
    $back_top.find('span').html(value);

    // Also change the back bottom value
    $back_bottom.find('span').html(value);

    // Then animate
    TweenMax.to($top, 0.8, {
      rotationX: '-180deg',
      transformPerspective: 300,
      ease: Quart.easeOut,
      onComplete: function() {

        $top.html(value);

        $bottom.html(value);

        TweenMax.set($top, {
          rotationX: 0
        });
      }
    });

    TweenMax.to($back_top, 0.8, {
      rotationX: 0,
      transformPerspective: 300,
      ease: Quart.easeOut,
      clearProps: 'all'
    });
  },

  checkDay: function(value, $el_1, $el_2) {

    var val_1 = value.toString().charAt(0),
      val_2 = value.toString().charAt(1),
      fig_1_value = $el_1.find('.top').html(),
      fig_2_value = $el_2.find('.top').html();

    if (value >= 10) {

      // Animate only if the figure has changed
      if (fig_1_value !== val_1) this.animateFigure($el_1, val_1);
      if (fig_2_value !== val_2) this.animateFigure($el_2, val_2);
    } else {

      // If we are under 10, replace first figure with 0
      if (fig_1_value !== '0') this.animateFigure($el_1, 0);
      if (fig_2_value !== val_1) this.animateFigure($el_2, val_1);
    }
  }
};

Countdown.init();

var Countdown = {

  // Backbone-like structure
  $el: $('.countdown2'),

  // Params
  countdown_interval: null,
  total_seconds: 0,

  // Initialize the countdown  
  init: function() {
    var Today           = new Date();
    var Todayday        = Today.getDate(); // getDay() is an integer corresponding to the day of the week: 0 for Sunday, 1 for Monday, 2 for Tuesday, and so on.
    var Todayhours      = Today.getHours();
    var Todayminutes    = Today.getMinutes();
    var Todayseconds    = Today.getSeconds();

    var DeadLine        = new Date('January 22, 2022 23:59');
    var DeadLineday     = DeadLine.getDate();
    var DeadLinehours   = DeadLine.getUTCHours(); // I'm not sure why getHours() here is "loaded jangá"
    var DeadLineminutes = DeadLine.getMinutes();
    var DeadLineseconds = DeadLine.getSeconds();

    // DOM
    this.$ = {
      days:     this.$el.find('.bloc-time.days .figure'),
      hours:    this.$el.find('.bloc-time.hours .figure'),
      minutes:  this.$el.find('.bloc-time.min .figure'),
      seconds:  this.$el.find('.bloc-time.sec .figure')
    };

    // Init countdown values
    this.values = {
      days:     DeadLineday - Todayday,
      hours:    DeadLinehours - Todayhours,
      minutes:  DeadLineminutes - Todayminutes,
      seconds:  DeadLineseconds - Todayseconds
    };

    // Initialize total seconds
    // this.total_seconds = ((this.values.days * 24) + (this.values.hours * 60 * 60 + (this.values.minutes * 60))) + this.values.seconds;
    this.total_seconds = this.values.seconds + (this.values.minutes * 60) + (this.values.hours * 60 * 60) + (this.values.days * 24 * 60 * 60);

    // Animate countdown to the end 
    this.count();
  },

  count: function() {

    var that = this,
      $day_1  = this.$.days.eq(0),
      $day_2  = this.$.days.eq(1),
      $hour_1 = this.$.hours.eq(0),
      $hour_2 = this.$.hours.eq(1),
      $min_1  = this.$.minutes.eq(0),
      $min_2  = this.$.minutes.eq(1),
      $sec_1  = this.$.seconds.eq(0),
      $sec_2  = this.$.seconds.eq(1);

    this.countdown_interval = setInterval(function() {

      if (that.total_seconds > 0) {

        --that.values.seconds;

        if (that.values.minutes >= 0 && that.values.seconds <= 0) {

          that.values.seconds = 59;
          --that.values.minutes;
        } // end if

        if (that.values.hours >= 0 && that.values.minutes <= 0) {

          that.values.minutes = 59;
          --that.values.hours;
        } // end if

        if (that.values.days >= 0 && that.values.hours <= 0) {

          that.values.hours = 24;
          --that.values.days;
        } // end if

        // Update DOM values
        // Days
        that.checkDay(that.values.days, $day_1, $day_2);

        // Hours
        that.checkDay(that.values.hours, $hour_1, $hour_2);

        // Minutes
        that.checkDay(that.values.minutes, $min_1, $min_2);

        // Seconds
        that.checkDay(that.values.seconds, $sec_1, $sec_2);

        --that.total_seconds;
      } // end if(that.total_seconds > 0)
      else {
        clearInterval(that.countdown_interval);
      }
    }, 1000);
  },

  animateFigure: function($el, value) {

    var that = this,
      $top = $el.find('.top'),
      $bottom = $el.find('.bottom'),
      $back_top = $el.find('.top-back'),
      $back_bottom = $el.find('.bottom-back');

    // Before we begin, change the back value
    $back_top.find('span').html(value);

    // Also change the back bottom value
    $back_bottom.find('span').html(value);

    // Then animate
    TweenMax.to($top, 0.8, {
      rotationX: '-180deg',
      transformPerspective: 300,
      ease: Quart.easeOut,
      onComplete: function() {

        $top.html(value);

        $bottom.html(value);

        TweenMax.set($top, {
          rotationX: 0
        });
      }
    });

    TweenMax.to($back_top, 0.8, {
      rotationX: 0,
      transformPerspective: 300,
      ease: Quart.easeOut,
      clearProps: 'all'
    });
  },

  checkDay: function(value, $el_1, $el_2) {

    var val_1 = value.toString().charAt(0),
      val_2 = value.toString().charAt(1),
      fig_1_value = $el_1.find('.top').html(),
      fig_2_value = $el_2.find('.top').html();

    if (value >= 10) {

      // Animate only if the figure has changed
      if (fig_1_value !== val_1) this.animateFigure($el_1, val_1);
      if (fig_2_value !== val_2) this.animateFigure($el_2, val_2);
    } else {

      // If we are under 10, replace first figure with 0
      if (fig_1_value !== '0') this.animateFigure($el_1, 0);
      if (fig_2_value !== val_1) this.animateFigure($el_2, val_1);
    }
  }
};

Countdown.init();

/* OTHER COUNTER */

$(".counting").each(function () {
  var $this = $(this),
    countTo = $this.attr("data-count");

  $({ countNum: $this.text() }).animate(
    {
      countNum: countTo,
    },

    {
      duration: 3000,
      easing: "linear",
      step: function () {
        $this.text(Math.floor(this.countNum));
      },
      complete: function () {
        $this.text(this.countNum);
      },
    }
  );
});

$("#slider-item-1-right").click(function () {
  $("#slider-item-1-right").toggleClass("d-none");
  $("#slider-item-1-left").toggleClass("d-block");
});

$("#slider-item-1-left").click(function () {
  $("#slider-item-1-right").toggleClass("d-block");
  $("#slider-item-1-left").removeClass("d-block");
});

$("#slider-item-2-right").click(function () {
  $("#slider-item-2-right").toggleClass("d-none");
  $("#slider-item-2-left").toggleClass("d-block");
});

$("#slider-item-2-left").click(function () {
  $("#slider-item-2-right").toggleClass("d-block");
  $("#slider-item-2-left").removeClass("d-block");
});

$("#slider-item-3-right").click(function () {
  $("#slider-item-3-right").toggleClass("d-none");
  $("#slider-item-3-left").toggleClass("d-block");
});

$("#slider-item-3-left").click(function () {
  $("#slider-item-3-right").toggleClass("d-block");
  $("#slider-item-3-left").removeClass("d-block");
});


// IMAGE UPLOAD

$('.input-images-2').imageUploader({
  label: "Dosyaları buraya sürükleyip bırakın veya göz atmak için tıklayın",
  imagesInputName: 'photos',
  preloadedInputName: 'old'
});

$('.input-images-3').imageUploader({
  label: "Dosyaları buraya sürükleyip bırakın veya göz atmak için tıklayın",
  imagesInputName: 'photos',
  preloadedInputName: 'old'
});

$('.mystaff_hide').addClass('collapse');

$('#mystuff').change(function(){
    var selector = '.mystaff_' + $(this).val();

    $('.mystaff_hide').collapse('hide');

    $(selector).collapse('show');
});
