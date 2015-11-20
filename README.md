#E-Academy
###Team Monus

##Members:
* MariyaSteffanova - Мария Стефанова (MariyaSteffanova)
* Aleksandra92 - Александра Стойчева (aleksandra992)
* dany90 - Даниел Попов (damy90)
* zhenia.racheva - Женя Рачева (zhenyaracheva)
* frowstyl - Александър Марков (fr0wsTyl)

##About the project:
![start screen](https://raw.githubusercontent.com/Momus-Telerik-Academy/Students-Learning-System/master/screenshots/Home-E-Academy.jpg)
E-Academy is an amazing place for everyone who is interested in learning. 
Here you may find solutions to your problems that have already been solved by other users. 
You can also add new materials and share them with everyone. 
E-Academy is here. Now. Freely.
##Project architecture
###Models
![DB models class diagram](https://raw.githubusercontent.com/Momus-Telerik-Academy/Students-Learning-System/master/screenshots/ClassDiagram1.png)
###Api
####CategoriesController
* Get() - returns all available categories. Path: "api/Categories"
* Get(int id) - returns the cattegory with matching id if any. Path: "api/Categories/{id}"
* Put(int id, CategoryRequestModel updates) - updates an existing category
	* Path: "api/Categories/{id}"
	* Parameters
		* id: integer number passed as url parameter
		* updates: CategoryRequestModel object passed in the request content.
* Post(CategoryRequestModel categoryModel) - adds a new category.
	* Path: "api/Categories"
	* Parameter: CategoryRequestModel categoryModel passed in the request content.
####CommentsController
* Post(CommentRequestModel commentModel) - adds a new comment
	* Path: "api/Comments"
	* Parameters: CommentRequestModel commentModel passed in the request content.
	* Requires registration
####DislikesController
* Post(int id) - Increases dislikes count for a comment
	* Path: "Api/Dislikes/{id}"
	* Parameters: int id - comment id
	* Requires registration

####LikesController
* Post(int id) - Increases likes count for a comment
	* Path: "Api/Likes/{id}"
	* Parameters: int id - comment id
	* Requires registration

####SectionsController
* Get() - returns all available sections Path: "api/Sections"
* Get(int id) - returns the section with matching id if any. Path: "api/Sections/{id}"
* Put(int id, SectionRequestModel updates) - updates an existing section 
	* Path: "api/Sections/{id}"
	* Parameters
		* id: integer number passed as url parameter
		* updates: SectionRequestModel object passed in the request content.
* Post(SectionRequestModel  sectionModel) - adds a new section to a category.
	* Path: "api/Sections"
	* Parameter: SectionRequestModel sectionModel passed in the request content.

####TopicsController
* Get(int id) - returns the topic with matching id if any. Path: "api/Topics/{id}"
* Post(TopicRequestModel requestTopic) - adds a new topic to a section.
	* Path: "api/Topics"
	* Parameter: TopicRequestModel requestTopic passed in the request content.
	* Requires registration
* IHttpActionResult Put(int id, TopicRequestModel requestTopic) - updates existing topic
	* Path: "api/Topics"
	* Parameters: 
		* int id - existing topic id
		* TopicRequestModel requestTopic - updated topic model
	* Requires registration
* Task<IHttpActionResult> Put(int topicId, HttpRequestMessage upload)
	* Path: "api/upload/{topicId}"
		* int id - existing topic id
		* HttpRequestMessage upload - ???
	* Requires registration

GitHub: https://github.com/Momus-Telerik-Academy/Students-Learning-System

