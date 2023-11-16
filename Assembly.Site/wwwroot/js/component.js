
window.openOperationModal = function () {
    const modalEl = document.querySelector("#operation-modal");
    const backdropClasses = ['block', 'bg-gray-900/50', 'dark:bg-gray-900/80', 'inset-0', 'z-40'];
    const modalELBarClasses = modalEl.classList
    const isHidden = modalELBarClasses.contains('hidden')
    if (isHidden) {
        modalELBarClasses.remove('hidden');

        backdropClasses.forEach((className) => {
            modalELBarClasses.add(className)
        })
    }
}
window.closeOperationModal = function () {
    const modalEl = document.querySelector("#operation-modal");
    const backdropClasses = ['block', 'bg-gray-900/50', 'dark:bg-gray-900/80', 'inset-0', 'z-40'];
    const modalELBarClasses = modalEl.classList
    modalELBarClasses.add('hidden')
    backdropClasses.forEach((className) => {
        modalELBarClasses.remove(className)
    })
}
window.closeEditFormOperation = function()
{
    const modalEl = document.querySelector('#edit-operation-modal');
    const backdropClasses = ['block', 'bg-gray-900/50', 'dark:bg-gray-900/80', 'inset-0', 'z-40'];
    const modalELBarClasses = modalEl.classList
    modalELBarClasses.add('hidden')
    backdropClasses.forEach((className) => {
        modalELBarClasses.remove(className)
    })
}
window.openEditFormOperationModal = function()
{
    const element = document.querySelector('#edit-operation-modal');
    const backdropClasses = ['block', 'bg-gray-900/50', 'dark:bg-gray-900/80', 'inset-0', 'z-40'];
    const modalELBarClasses = element.classList
    const isHidden = modalELBarClasses.contains('hidden')
    if (isHidden) {
        modalELBarClasses.remove('hidden');

        backdropClasses.forEach((className) => {
            modalELBarClasses.add(className)
        })
    }
}