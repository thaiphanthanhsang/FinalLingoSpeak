using LingoSpeakBackend.DTOs;
using LingoSpeakBackend.Exceptions; 
using LingoSpeakBackend.Mappers;
using LingoSpeakBackend.Models;
using LingoSpeakBackend.Repositories.Interfaces;
using LingoSpeakBackend.Services.Interfaces;

namespace LingoSpeakBackend.Services.Implementations;

public class ConversationService : IConversationService
{
    private readonly IConversationRepository _conversationRepo;

    public ConversationService(IConversationRepository conversationRepo)
    {
        _conversationRepo = conversationRepo;
    }

    public async Task<IEnumerable<ConversationResponse>> GetAllConversationsAsync()
    {
        var conversations = await _conversationRepo.GetAllAsync();
        return conversations.Select(c => c.ToConversationResponse()).ToList();
    }

    public async Task<ConversationResponse?> GetConversationByIdAsync(int id)
    {
        var conversation = await _conversationRepo.GetByIdAsync(id);
        if (conversation == null)
        {
            throw new NotFoundException($"Không tìm thấy bài hội thoại mẫu có ID {id}.");
        }
        return conversation.ToConversationResponse();
    }

    public async Task<ConversationResponse> CreateConversationAsync(ConversationCreateRequest request)
    {
        var conversation = request.ToConversation();

        await _conversationRepo.AddAsync(conversation);
        await _conversationRepo.SaveChangesAsync();

        return conversation.ToConversationResponse();
    }

    public async Task<bool> UpdateConversationAsync(int id, ConversationUpdateRequest request)
    {
        var conversation = await _conversationRepo.GetByIdAsync(id);
        if (conversation == null)
        {
            throw new NotFoundException($"Không thể cập nhật vì không tìm thấy bài hội thoại mẫu có ID {id}.");
        }

        if (request.Topic != null) conversation.Topic = request.Topic;
        if (request.Speaker1Name != null) conversation.Speaker1Name = request.Speaker1Name;
        if (request.Speaker2Name != null) conversation.Speaker2Name = request.Speaker2Name;

        if (request.Messages != null)
        {
            conversation.Messages.Clear(); 
            foreach (var m in request.Messages)
            {
                conversation.Messages.Add(new ConversationMessage
                {
                    SenderName = m.SenderName,
                    Content = new Translation
                    {
                        English = m.Translation?.English ?? string.Empty,
                        Vietnamese = m.Translation?.Vietnamese ?? string.Empty
                    },
                    Order = m.Order ?? 0,
                });
            }
        }

        _conversationRepo.Update(conversation);
        return await _conversationRepo.SaveChangesAsync();
    }

    public async Task<bool> DeleteConversationAsync(int id)
    {
        var conversation = await _conversationRepo.GetByIdAsync(id);
        if (conversation == null)
        {
            throw new NotFoundException($"Không thể xóa vì không tìm thấy bài hội thoại mẫu có ID {id}.");
        }

        _conversationRepo.Delete(conversation);
        return await _conversationRepo.SaveChangesAsync();
    }
}