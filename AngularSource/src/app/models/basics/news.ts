export class News {
    constructor(
        public newsID: number=0,
        public newsCategory?: string ,
        public newsGenre?: string,
        public newsName?: string,
        public newsDescription?: string,
        public newsDateTime?: Date,
        public newsMainPictureLink?: string,
        public newsVideoLink?: string,
        public newsPrefered?: boolean
        ) {}
}