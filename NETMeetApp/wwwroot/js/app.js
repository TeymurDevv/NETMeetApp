// the arrow in dropbox
const arrows = document.querySelectorAll('.dropbox__icon');
// to open and close the dropbox on click
arrows.forEach((arrow) => {
    arrow.addEventListener('click', () => {
        const dropbox = arrow.parentNode.parentNode;
        const description = dropbox.querySelector('.dropbox__description');

        if (dropbox.classList.contains('dropbox--open')) {
            description.style.maxHeight = null;
            description.style.opacity = 0;
        } else {
            description.style.maxHeight = description.scrollHeight + 'px';
            description.style.opacity = 1;
        }

        dropbox.classList.toggle('dropbox--open');
    });
});

// the hamburger menu
const hamburger = document.querySelector('.hamburger');

// to open and close the menu on click
hamburger.addEventListener('click', () => {
    const parent = hamburger.parentNode;
    parent.classList.toggle('menu--open');
});
