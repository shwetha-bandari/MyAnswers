using SimpleBlog.API.Infrastructure;
using FakeItEasy;
using Xunit;
using SimpleBlog.API.Controllers;
using SimpleBlog.API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.API.Tests
{
    public class PostsRepositoryTests
    {
        protected IPostsRepository FakePostsRepository;
        protected PostsController FakePostsController;

        [Fact]
        public async Task PostsRepository_CallsClient_And_ReturnsCorrectType_WhenGettingPosts()
        {
            //  Arrange
            FakePostsRepository = A.Fake<IPostsRepository>();
            FakePostsController = new PostsController(FakePostsRepository);

            //  Act
            var fakeModel = await FakePostsController.Get();

            //  Assert
            A.CallTo(() => FakePostsRepository.GetN<Post>(100)).MustHaveHappenedOnceExactly();
            Assert.IsType(typeof(ActionResult<string>), fakeModel);
        }

        protected ICommentsRepository FakeCommentsRepository;
        protected CommentsController FakeCommentsController;
        public int postid;

        [Fact]
        public async Task CommentsRepository_CallsClient_And_ReturnsCorrectType_WhenGettingComments()
        {
            //  Arrange
            FakeCommentsRepository = A.Fake<ICommentsRepository>();
            FakeCommentsController = new CommentsController(FakeCommentsRepository);

            //  Act
            var fakeModel = await FakeCommentsController.Get(this.postid);

            ////  Assert
            A.CallTo(() => FakePostsRepository.GetN<Comment>(100)).MustHaveHappenedOnceExactly();
            Assert.IsType(typeof(ActionResult<string>), fakeModel);
        }

    }
}
