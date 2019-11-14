// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  hasTranslations: false,
  language:'he'
};

export const mainUrl = 'http://localhost:50240/api/';
export const translationsUrl = mainUrl + 'translations/';
export const programsUrl = mainUrl + 'programs/';
export const blogsUrl = mainUrl + 'blogs/';
export const newsUrl = mainUrl + 'news/';
export const blogCommentsUrl = mainUrl + 'blogComments/';



/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
