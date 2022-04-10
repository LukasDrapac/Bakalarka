console.log("Hello")
async function button() {
    let directoryHandle = await window.showDirectoryPicker();
    console.log(directoryHandle);
}
