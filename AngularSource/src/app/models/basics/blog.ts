export class Blog {
    constructor(
        public blogId: number = 0,
        public blogCategory?: string ,
        public blogName?: string,
        public blogPublisher?: string,
        public blogContent?: string,
        public blogDate?: Date,
        public blogMainPictureLink?: string
        ) {}
}