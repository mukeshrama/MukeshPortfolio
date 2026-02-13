// Chatbot functionality
(function() {
    'use strict';

    console.log('=== CHATBOT INITIALIZATION START ===');

    function initChatbot() {
        console.log('Initializing chatbot...');

        const chatbotToggle = document.getElementById('chatbot-toggle');
        const chatbotContainer = document.getElementById('chatbot-container');
        const closeChat = document.getElementById('close-chat');
        const chatbotInput = document.getElementById('chatbot-input');
        const sendMessage = document.getElementById('send-message');
        const messagesContainer = document.getElementById('chatbot-messages');

        console.log('Chatbot elements:', {
            toggle: chatbotToggle ? 'found' : 'NOT FOUND',
            container: chatbotContainer ? 'found' : 'NOT FOUND',
            closeChat: closeChat ? 'found' : 'NOT FOUND',
            input: chatbotInput ? 'found' : 'NOT FOUND',
            sendButton: sendMessage ? 'found' : 'NOT FOUND',
            messages: messagesContainer ? 'found' : 'NOT FOUND'
        });

        if (!chatbotToggle || !chatbotContainer) {
            console.error('CRITICAL: Chatbot elements not found!');
            return;
        }

        // Force display
        chatbotToggle.style.cssText = `
            display: flex !important;
            position: fixed !important;
            bottom: 30px !important;
            right: 30px !important;
            z-index: 999999 !important;
            width: 60px !important;
            height: 60px !important;
            visibility: visible !important;
            opacity: 1 !important;
        `;

        console.log('Chatbot toggle styled. Computed style:', {
            display: window.getComputedStyle(chatbotToggle).display,
            position: window.getComputedStyle(chatbotToggle).position,
            zIndex: window.getComputedStyle(chatbotToggle).zIndex,
            visibility: window.getComputedStyle(chatbotToggle).visibility,
            opacity: window.getComputedStyle(chatbotToggle).opacity
        });

        console.log('Chatbot elements found and initialized successfully');

        // Toggle chatbot
        chatbotToggle.addEventListener('click', () => {
            console.log('Toggle clicked');
            chatbotContainer.style.display = 'flex';
            chatbotToggle.style.display = 'none';
        });

        closeChat.addEventListener('click', (e) => {
            e.preventDefault();
            e.stopPropagation();
            console.log('Close clicked');
            chatbotContainer.style.display = 'none';
            chatbotToggle.style.display = 'flex';
        });

    // Send message function
    function sendUserMessage() {
        const message = chatbotInput.value.trim();
        if (message === '') return;

        // Add user message
        addMessage(message, 'user');
        chatbotInput.value = '';

        // Show typing indicator
        showTypingIndicator();

        // Simulate bot response
        setTimeout(() => {
            hideTypingIndicator();
            const response = getBotResponse(message);
            addMessage(response.text, 'bot', response.quickReplies);
        }, 1000);
    }

    // Add message to chat
    function addMessage(text, sender, quickReplies = null) {
        const messageDiv = document.createElement('div');
        messageDiv.className = sender === 'user' ? 'user-message' : 'bot-message';

        const avatar = document.createElement('div');
        avatar.className = 'message-avatar';
        avatar.textContent = sender === 'user' ? '👤' : '🤖';

        const content = document.createElement('div');
        content.className = 'message-content';
        content.textContent = text;

        if (quickReplies && quickReplies.length > 0) {
            const quickRepliesDiv = document.createElement('div');
            quickRepliesDiv.className = 'quick-replies';
            quickRepliesDiv.style.marginTop = '0.75rem';

            quickReplies.forEach(reply => {
                const button = document.createElement('button');
                button.className = 'quick-reply';
                button.textContent = reply.text;
                button.setAttribute('data-message', reply.message);
                button.addEventListener('click', (e) => {
                    const msg = e.target.getAttribute('data-message');
                    chatbotInput.value = msg;
                    sendUserMessage();
                });
                quickRepliesDiv.appendChild(button);
            });

            content.appendChild(quickRepliesDiv);
        }

        messageDiv.appendChild(avatar);
        messageDiv.appendChild(content);
        messagesContainer.appendChild(messageDiv);
        messagesContainer.scrollTop = messagesContainer.scrollHeight;
    }

    // Typing indicator
    function showTypingIndicator() {
        const typingDiv = document.createElement('div');
        typingDiv.className = 'bot-message typing-message';
        typingDiv.innerHTML = `
            <div class="message-avatar">🤖</div>
            <div class="message-content typing-indicator">
                <span></span><span></span><span></span>
            </div>
        `;
        messagesContainer.appendChild(typingDiv);
        messagesContainer.scrollTop = messagesContainer.scrollHeight;
    }

    function hideTypingIndicator() {
        const typingMessage = messagesContainer.querySelector('.typing-message');
        if (typingMessage) {
            typingMessage.remove();
        }
    }

    // Bot responses
    function getBotResponse(message) {
        const lowerMessage = message.toLowerCase();

        // About
        if (lowerMessage.includes('about') || lowerMessage.includes('who are you') || lowerMessage.includes('mukesh')) {
            return {
                text: "Mukesh Thakur is a Full Stack .NET Developer with 3+ years of experience in enterprise applications, REST APIs, and Windows development. Would you like to know more about his skills or experience?",
                quickReplies: [
                    { text: 'Skills', message: 'What are your skills?' },
                    { text: 'Experience', message: 'Tell me about work experience' }
                ]
            };
        }

        // Skills
        if (lowerMessage.includes('skill') || lowerMessage.includes('technology') || lowerMessage.includes('tech stack')) {
            return {
                text: "Mukesh specializes in C#, ASP.NET Core, SQL Server, REST APIs, Entity Framework, and more. He also works with WinForms, IIS, Azure DevOps, and has experience with SAP RFC integration.",
                quickReplies: [
                    { text: 'View All Skills', message: 'Show all skills' },
                    { text: 'Projects', message: 'Show me projects' }
                ]
            };
        }

        // Projects
        if (lowerMessage.includes('project') || lowerMessage.includes('work') || lowerMessage.includes('portfolio')) {
            return {
                text: "Mukesh has worked on various projects including web applications, REST APIs, and Windows desktop applications. You can check out his projects page for more details!",
                quickReplies: [
                    { text: 'Contact', message: 'How can I contact?' },
                    { text: 'Experience', message: 'Work experience' }
                ]
            };
        }

        // Contact
        if (lowerMessage.includes('contact') || lowerMessage.includes('email') || lowerMessage.includes('reach')) {
            return {
                text: "You can reach Mukesh at:\n📧 mukeshraman1999@gmail.com\n📱 +91 7391916147\n📍 Mumbai, India\n\nOr connect via LinkedIn and GitHub!",
                quickReplies: [
                    { text: 'LinkedIn', message: 'LinkedIn profile' },
                    { text: 'GitHub', message: 'GitHub profile' }
                ]
            };
        }

        // Experience
        if (lowerMessage.includes('experience') || lowerMessage.includes('job') || lowerMessage.includes('career')) {
            return {
                text: "Mukesh is currently working as an Associate Consultant at Datamatics Global Services since Feb 2023. He previously worked as a Young Graduate at TCS. He has experience in web development, API design, and production support.",
                quickReplies: [
                    { text: 'Skills', message: 'What skills?' },
                    { text: 'Projects', message: 'Show projects' }
                ]
            };
        }

        // Education
        if (lowerMessage.includes('education') || lowerMessage.includes('degree') || lowerMessage.includes('study')) {
            return {
                text: "Mukesh has a B.Sc in Computer Science from KC College - Mumbai University (CGPA: 9.28/10) and completed HSC in Science with 75.60%.",
                quickReplies: [
                    { text: 'Skills', message: 'Technical skills' },
                    { text: 'Contact', message: 'Contact info' }
                ]
            };
        }

        // LinkedIn/GitHub
        if (lowerMessage.includes('linkedin')) {
            return {
                text: "Connect with Mukesh on LinkedIn: https://linkedin.com/in/mukesh-thakur-601040196",
                quickReplies: []
            };
        }

        if (lowerMessage.includes('github')) {
            return {
                text: "Check out Mukesh's GitHub: https://github.com/mukeshrama",
                quickReplies: []
            };
        }

        // Default response
        return {
            text: "I'm here to help! You can ask me about Mukesh's skills, projects, work experience, education, or contact information.",
            quickReplies: [
                { text: 'Skills', message: 'What are your skills?' },
                { text: 'Projects', message: 'Show projects' },
                { text: 'Contact', message: 'How to contact?' }
            ]
        };
    }

    // Send message on button click
    sendMessage.addEventListener('click', sendUserMessage);

    // Send message on Enter key
    chatbotInput.addEventListener('keypress', (e) => {
        if (e.key === 'Enter') {
            sendUserMessage();
        }
    });

    // Quick reply buttons in initial message
    document.querySelectorAll('.quick-reply').forEach(button => {
        button.addEventListener('click', (e) => {
            const message = e.target.getAttribute('data-message');
            chatbotInput.value = message;
            sendUserMessage();
        });
    });
}

// Initialize on DOM ready and window load (double ensure)
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', initChatbot);
} else {
    initChatbot();
}

window.addEventListener('load', function() {
    const toggle = document.getElementById('chatbot-toggle');
    if (toggle) {
        toggle.style.display = 'flex';
    }
});

})();
