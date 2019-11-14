export class BlogComment {
    constructor(
        public commentId: number =0,
        public blogId: number =0,
        public commentContent?: string
        ) {}
}