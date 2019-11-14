import { ImageService } from '../../services/image.service';

export class Program {
    public programMainPicture : any
    public imageService: ImageService

    constructor(
        public programId: number=0,
        public programCategory?: string,
        public programGenre?: string,
        public programName?: string,
        public programDescription ?: string,
        public programDateTime ?: Date,
        public programMainPictureLink ?: string,
        public programVideoLink ?: string)
    {
        //this.getImageFromService()
    }

    isImageLoading: boolean;

    getImageFromService() {
        this.isImageLoading = true;
        console.log(this.programMainPictureLink)
        this.imageService.getImage(this.programMainPictureLink)
        .subscribe(data => {
            this.createImageFromBlob(data);
            this.isImageLoading = false;
        }, error => {
            this.isImageLoading = false;
            console.log(error);
        });
    }

    createImageFromBlob(image: Blob) {
        let reader = new FileReader();
        reader.addEventListener("load", () => {
            this.programMainPicture = reader.result;
        }, false);
    
        if (image) {
            reader.readAsDataURL(image);
        }
    }
}